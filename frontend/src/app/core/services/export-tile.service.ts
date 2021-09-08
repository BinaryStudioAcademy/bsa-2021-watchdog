import { Injectable } from '@angular/core';
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';
import * as FileSaver from 'file-saver';
import 'blob';
import { ExportType } from '@shared/models/tile/enums/export-type';

const JsPDF = jsPDF;

@Injectable({
    providedIn: 'root'
})
export class ExportTileService {
    exportTile(exportType: ExportType, data: any) {
        const smallPdf = 200;
        const mediumPdf = 440;
        const bigPdf = 880;
        html2canvas(data).then(canvas => {
            if (exportType === ExportType.Jpg) {
                canvas.toBlob((blob) => {
                    FileSaver.saveAs(blob, `${new Date().toLocaleString().replace(':', '_')}.jpg`);
                });
            }
            if (exportType === ExportType.Png) {
                canvas.toBlob((blob) => {
                    FileSaver.saveAs(blob, `${new Date().toLocaleString().replace(':', '_')}.png`);
                });
            }
            if (exportType === ExportType.Pdf) {
                const contentDataURL = canvas.toDataURL('image/png', 1.0);
                const pdf = new JsPDF('p', 'mm', 'a4');
                if (canvas.width >= smallPdf && canvas.width <= mediumPdf) {
                    pdf.addImage(contentDataURL, 'PNG', 60, 10, canvas.height / 6, 0);
                }
                if (canvas.width >= mediumPdf && canvas.width <= bigPdf) {
                    pdf.addImage(contentDataURL, 'PNG', 35, 10, canvas.height / 4, 0);
                }
                if (canvas.width >= bigPdf) {
                    pdf.addImage(contentDataURL, 'PNG', 25, 10, canvas.height / 2.7, 0);
                }
                pdf.save(`${new Date().toLocaleString().replace(':', '_')}.pdf`);
            }
        });
    }
}
