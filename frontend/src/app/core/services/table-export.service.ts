import { Injectable } from '@angular/core';
import * as FileSaver from 'file-saver';
import * as XLSXManager from 'xlsx';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

const JsPDF = jsPDF;

@Injectable({
    providedIn: 'root'
})
export class TableExportService {
    private static saveAsExcelFile(buffer: BlobPart[], fileName: string, type: string, extension: string): void {
        const data: Blob = new Blob(buffer, { type });
        FileSaver.saveAs(data, `${fileName}.${extension}`);
    }

    private static getFileFullName(fileName: string): string {
        return `${fileName} ${new Date().toLocaleString().replace(':', '_')}`;
    }

    exportPdf(arrayOfItemsToWrite: any[], fileName: string, orientation: 'landscape' | 'portrait' = 'landscape'): void {
        const doc = new JsPDF({ orientation, unit: 'px', compress: true });
        if (arrayOfItemsToWrite.length) {
            const cols: string[][] = [Object.keys(arrayOfItemsToWrite[0])];
            const pxPerSymbol = 8;

            autoTable(doc, {
                head: cols,
                body: arrayOfItemsToWrite.map(item => Object.values(item)),
                columnStyles: cols[0].reduce((acc, propName, index) => ({
                    ...acc, [index]: { minCellWidth: propName.length * pxPerSymbol }
                }), {}),
            });
        }
        doc.save(`${TableExportService.getFileFullName(fileName)}.pdf`);
    }

    exportExcel(arrayOfItemsToWrite: any[], fileName: string): void {
        const extension = 'xlsx';
        const fileType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
        const worksheet = XLSXManager.utils.json_to_sheet(arrayOfItemsToWrite);
        const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
        const excelBuffer = XLSXManager.write(workbook, { bookType: extension, type: 'array' });
        TableExportService.saveAsExcelFile([excelBuffer], TableExportService.getFileFullName(fileName), fileType, extension);
    }
}
