import { FormGroup } from '@angular/forms';
import { KeyValuePair } from '@shared/models/key-value-pair';
import { toString } from '@core/utils/kvp.utils';
import { TestMethod } from '@shared/models/test/enums/test-method';

export const getUrl = (form: FormGroup) => {
    const protocol = form.controls.protocol.value.label;
    const host = form.controls.host.value;
    const path = !form.controls.path.value ? '' : `/${form.controls.path.value}`;
    const params = form.controls.parameters.value as KeyValuePair[];
    const paramsString = params[0]?.key ? `?${params.filter(x => x.key).map(x => toString(x)).join('&')}` : '';
    return `${protocol}://${host === '' ? 'example.com' : host}${path}${paramsString}`;
};

export const hasBody = (method: string | TestMethod) => {
    if (typeof (method) === 'string') {
        return method !== 'GET' && method !== 'DELETE';
    }
    return method !== TestMethod.Get && method !== TestMethod.Delete;
};

export const jsonToXml = (objectString: string, tab: string = null, objectName: string = 'object') => {
    try {
        const object = {};
        object[objectName] = JSON.parse(objectString);

        const toXml = (value: any, name: string, ind: string) => {
            let xml = '';
            if (value instanceof Array) {
                for (let i = 0, n = value.length; i < n; i += 1) {
                    xml += `${ind + toXml(value[i], name, `${ind}\t`)}`;
                }
            } else if (typeof (value) === 'object') {
                if (value && Object.keys(value).length) {
                    let hasChild = false;
                    xml += `${ind}<${name}`;
                    Object.keys(value).forEach(m => {
                        if (m.charAt(0) === '@') {
                            xml += ` ${m.substr(1)}="${value[m].toString()}"`;
                        } else {
                            hasChild = true;
                        }
                    });
                    xml += hasChild ? '>\n' : '/>\n';
                    if (hasChild) {
                        Object.keys(value).forEach(m => {
                            if (m === '#text') {
                                xml += value[m];
                            } else if (m === '#cdata') {
                                xml += `<![CDATA[${value[m]}]]>`;
                            } else if (m.charAt(0) !== '@') {
                                xml += toXml(value[m], m, `${ind}\t`);
                            }
                        });
                        xml += `${xml.charAt(xml.length - 1) === '\n' ? ind : ''}</${name}>\n`;
                    }
                }
            } else {
                xml += `${ind}<${name}>${value.toString()}</${name}>\n`;
            }
            return xml;
        };
        let result = '';
        Object.keys(object).forEach(m => {
            result += toXml(object[m], m, '');
        });
        return tab ? result.substring(0, result.length - 1).replace(/\t/g, tab) : result.replace(/\t|\n/g, '');
    } catch {
        return objectString;
    }
};

const parseXml = (xmlString: string): any => {
    if (DOMParser) {
        try {
            const xml = (new DOMParser()).parseFromString(xmlString, 'application/xml');
            return xml.getElementsByTagName('parsererror').length ? null : xml;
        } catch (e) {
            return null;
        }
    }
    return null;
};

export const xmlToJson = (txt: string, tab = null) => {
    const xmlObject: Document = parseXml(txt);
    if (!xmlObject) {
        return txt;
    }
    const helper = {
        toObj(xml: any) {
            let object: any = {};
            if (xml.nodeType === 1) { // element node ..
                if (xml.attributes.length) { // element with attributes  ..
                    for (let i = 0; i < xml.attributes.length; i += 1) {
                        object[`@${xml.attributes[i].nodeName}`] = (xml.attributes[i].nodeValue || '').toString();
                    }
                }
                if (xml.firstChild) { // element has child nodes ..
                    let textChild = 0;
                    let cdataChild = 0;
                    let hasElementChild = false;
                    for (let n = xml.firstChild; n; n = n.nextSibling) {
                        if (n.nodeType === 1) hasElementChild = true;
                        else if (n.nodeType === 3 && n.nodeValue.match(/[^ \f\n\r\t\v]/)) textChild += 1; // non-whitespace text
                        else if (n.nodeType === 4) cdataChild += 1; // cdata section node
                    }
                    if (hasElementChild) {
                        if (textChild < 2 && cdataChild < 2) { // structured element with evtl. a single text or/and cdata node ..
                            helper.removeWhite(xml);
                            for (let n = xml.firstChild; n; n = n.nextSibling) {
                                if (n.nodeType === 3) { // text node
                                    object['#text'] = helper.escape(n.nodeValue);
                                } else if (n.nodeType === 4) { // cdata node
                                    object['#cdata'] = helper.escape(n.nodeValue);
                                } else if (object[n.nodeName]) { // multiple occurence of element ..
                                    if (object[n.nodeName] instanceof Array) {
                                        object[n.nodeName][object[n.nodeName].length] = helper.toObj(n);
                                    } else {
                                        object[n.nodeName] = [object[n.nodeName], helper.toObj(n)];
                                    }
                                } else { // first occurence of element..
                                    object[n.nodeName] = helper.toObj(n);
                                }
                            }
                        } else if (!xml.attributes.length) {
                            object = helper.escape(helper.innerXml(xml));
                        } else {
                            object['#text'] = helper.escape(helper.innerXml(xml));
                        }
                    } else if (textChild) { // pure text
                        if (!xml.attributes.length) {
                            object = helper.escape(helper.innerXml(xml));
                        } else {
                            object['#text'] = helper.escape(helper.innerXml(xml));
                        }
                    } else if (cdataChild) { // cdata
                        if (cdataChild > 1) {
                            object = helper.escape(helper.innerXml(xml));
                        } else {
                            for (let n = xml.firstChild; n; n = n.nextSibling) {
                                object['#cdata'] = helper.escape(n.nodeValue);
                            }
                        }
                    }
                }
                if (!xml.attributes.length && !xml.firstChild) object = null;
            } else if (xml.nodeType === 9) { // document.node
                object = helper.toObj(xml.documentElement);
            }
            return object;
        },
        toJson(object: any, name: string, ind: string) {
            let json = name ? (`"${name}"`) : '';
            if (object instanceof Array) {
                const arr = object.map(x => helper.toJson(x, '', `${ind}\t`));
                json += `${(name ? ':[' : '[') + (arr.length > 1 ? (`\n${ind}\t${arr.join(`,\n${ind}\t`)}\n${ind}`) : arr.join(''))}]`;
            } else if (object === null) {
                json += `${name && ':'}null`;
            } else if (typeof (object) === 'object') {
                const arr = [];
                Object.keys(object).forEach(m => {
                    arr[arr.length] = helper.toJson(object[m], m, `${ind}\t`);
                });
                json += `${(name ? ':{' : '{') + (arr.length > 1 ? (`\n${ind}\t${arr.join(`,\n${ind}\t`)}\n${ind}`) : arr.join(''))}}`;
            } else if (typeof (object) === 'string') {
                json += `${name && ':'}"${object.toString()}"`;
            } else {
                json += (name && ':') + object.toString();
            }
            return json;
        },
        innerXml(node: Element) {
            let str = '';
            if ('innerHTML' in node) {
                str = node.innerHTML;
            } else {
                const asXml = (n: any) => {
                    let s = '';
                    if (n.nodeType === 1) {
                        s += `<${n.nodeName}`;
                        for (let i = 0; i < n.attributes.length; i += 1) {
                            s += ` ${n.attributes[i].nodeName}="${(n.attributes[i].nodeValue || '').toString()}"`;
                        }
                        if (n.firstChild) {
                            s += '>';
                            for (let c = n.firstChild; c; c = c.nextSibling) {
                                s += asXml(c);
                            }
                            s += `</${n.nodeName}>`;
                        } else {
                            s += '/>';
                        }
                    } else if (n.nodeType === 3) {
                        s += n.nodeValue;
                    } else if (n.nodeType === 4) {
                        s += `<![CDATA[${n.nodeValue}]]>`;
                    }
                    return s;
                };
                for (let c = node.firstChild; c; c = c.nextSibling) {
                    str += asXml(c);
                }
            }
            return str;
        },
        escape(text: string) {
            return text.replace(/[\\]/g, '\\\\')
                .replace(/["]/g, '\\"')
                .replace(/[\n]/g, '\\n')
                .replace(/[\r]/g, '\\r');
        },
        removeWhite(element: Document | ChildNode) {
            element.normalize();
            for (let n = element.firstChild; n;) {
                if (n.nodeType === 3) { // text node
                    if (!n.nodeValue.match(/[^ \f\n\r\t\v]/)) { // pure whitespace text node
                        const nxt = n.nextSibling;
                        element.removeChild(n);
                        n = nxt;
                    } else {
                        n = n.nextSibling;
                    }
                } else if (n.nodeType === 1) { // element node
                    helper.removeWhite(n);
                    n = n.nextSibling;
                } else { // any other node
                    n = n.nextSibling;
                }
            }
            return element;
        }
    };
    const json = helper.toJson(helper.toObj(helper.removeWhite(xmlObject)), '', '\t');
    return tab ? json.replace(/\t/g, tab) : json.replace(/\t|\n/g, '');
};

export const toPretty = (value: string, contentType: string) => {
    if (contentType === 'application/json') {
        try {
            return JSON.stringify(JSON.parse(value), null, 2);
        } catch {
            return value;
        }
    } else if (contentType === 'application/xml') {
        const xmlDoc = parseXml(value);
        if (!xmlDoc) {
            return value;
        }
        const xsltDoc = new DOMParser().parseFromString([
            // describes how we want to modify the XML - indent everything
            '<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform">',
            '  <xsl:strip-space elements="*"/>',
            '  <xsl:template match="para[content-style][not(text())]">', // change to just text() to strip space in text nodes
            '    <xsl:value-of select="normalize-space(.)"/>',
            '  </xsl:template>',
            '  <xsl:template match="node()|@*">',
            '    <xsl:copy><xsl:apply-templates select="node()|@*"/></xsl:copy>',
            '  </xsl:template>',
            '  <xsl:output indent="yes"/>',
            '</xsl:stylesheet>',
        ].join('\n'), 'application/xml');
        const xsltProcessor = new XSLTProcessor();
        xsltProcessor.importStylesheet(xsltDoc);
        const resultDoc = xsltProcessor.transformToDocument(xmlDoc);
        const resultXml = new XMLSerializer().serializeToString(resultDoc);
        return resultXml;
    }
    return value;
};
