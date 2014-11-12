HttpResponse response = context.Response;
string filename = context.Request.QueryString["filename"];

response.Clear();
response.ContentType = "application/pdf";
response.AddHeader("content-disposition", "attachment;filename=" + sFileName);
response.Cache.SetCacheability(HttpCacheability.NoCache);

System.IO.StringReader sr = new System.IO.StringReader(sHtml);
iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20f, 20f, 50f, 30f);

PdfWriter writer = PdfWriter.GetInstance(pdfDoc, response.OutputStream);
pdfDoc.Open();
XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
pdfDoc.Close();

response.Write(pdfDoc);
response.End();
