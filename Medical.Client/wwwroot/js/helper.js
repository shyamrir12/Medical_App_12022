﻿function downloadpdf(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/pdf;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}