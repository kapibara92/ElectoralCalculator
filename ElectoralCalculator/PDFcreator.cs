using ElectoralCalculator.Models;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Microsoft.Win32;

namespace ElectoralCalculator
{
    public class PDFcreator
    {
        PdfDocument pdf;
        PdfPage page;
        XFont titleFont;
        XFont regularFont;
        int yposition;
        XGraphics graph;
        int xposition;
        public PDFcreator()
        {
            pdf = new PdfDocument();
            page = pdf.AddPage();
            titleFont = new XFont("Times New Roman", 13, XFontStyle.Bold);
            regularFont = new XFont("Times New Roman", 13, XFontStyle.Regular);
            yposition = 30;
            graph = XGraphics.FromPdfPage(page);
            xposition = 30;
        }
        public void createTitle(string header)
        {
            XFont titleFont = new XFont("Arial", 16, XFontStyle.Bold);
            graph.DrawString(header, titleFont, XBrushes.Black, new XRect(xposition, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);
            yposition += 40;
        }
        public void addCandidateVotes(Collection<CandidateStatistic> candidatesStatistic, string title)
        {
            graph.DrawString(title, titleFont, XBrushes.Black, new XRect(xposition, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);
            yposition += 30;
            graph.DrawString("Candidat Name", titleFont, XBrushes.Black, new XRect(40, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Party", titleFont, XBrushes.Black, new XRect(280, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

            graph.DrawString("Votes", titleFont, XBrushes.Black, new XRect(420, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yposition += 20;
            foreach (CandidateStatistic candidat in candidatesStatistic)
            {
                string Name = candidat.CandidateName;
                string Party = candidat.Party;
                string Votes = candidat.Votes.ToString();
                graph.DrawString(Name, regularFont, XBrushes.Black, new XRect(40, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(Party, regularFont, XBrushes.Black, new XRect(280, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(Votes, regularFont, XBrushes.Black, new XRect(420, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                yposition = yposition + 20;
            }
        }
        public void addVotesStatistic(Collection<PartyStatistic> partyStatistic,string title)
        {
            graph.DrawString(title, titleFont, XBrushes.Black, new XRect(xposition, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);
            yposition += 30;
            graph.DrawString("Candidat Name", titleFont, XBrushes.Black, new XRect(40, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            graph.DrawString("Votes", titleFont, XBrushes.Black, new XRect(340, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yposition += 20;
            foreach (PartyStatistic party in partyStatistic)
            {
                string Name = party.Party;
                string Votes = party.NumberVotes.ToString();
                graph.DrawString(Name, regularFont, XBrushes.Black, new XRect(40, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(Votes, regularFont, XBrushes.Black, new XRect(340, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                yposition = yposition + 20;
            }
            }
        public void newPage() {
            page=pdf.AddPage();
            graph = XGraphics.FromPdfPage(page);
            yposition = 30;
        }
        public void AddParagraph(String title, String text)
        {
            yposition += 30;
            graph.DrawString(title, titleFont, XBrushes.Black, new XRect(40, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            graph.DrawString(text,regularFont, XBrushes.Black, new XRect(420, yposition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yposition += 20;

        }
        public void SavePdf()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".pdf";
            saveFile.Title = "Save pdf file";
           // saveFile.InitialDirectory=
            saveFile.Filter = "Pdf files (*.pdf)|*.pdf";
            try
            {
                Nullable<bool> result = saveFile.ShowDialog();
                if (result == true && saveFile.FileName != "")
                {
                    System.IO.FileStream path = (System.IO.FileStream)saveFile.OpenFile();
                    pdf.Save(path);
                }
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
    }
}
