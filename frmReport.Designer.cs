namespace QuanLyNhanSu_3Tang_ADO
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            stiRibbonViewerControl1 = new Stimulsoft.Report.Viewer.StiRibbonViewerControl();
            SuspendLayout();
            // 
            // stiRibbonViewerControl1
            // 
            stiRibbonViewerControl1.AllowDrop = true;
            stiRibbonViewerControl1.Location = new Point(13, 14);
            stiRibbonViewerControl1.Margin = new Padding(4, 5, 4, 5);
            stiRibbonViewerControl1.Name = "stiRibbonViewerControl1";
            stiRibbonViewerControl1.Report = null;
            stiRibbonViewerControl1.RightToLeft = RightToLeft.No;
            stiRibbonViewerControl1.ShowZoom = true;
            stiRibbonViewerControl1.Size = new Size(1092, 744);
            stiRibbonViewerControl1.TabIndex = 0;
            // 
            // frmReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 764);
            Controls.Add(stiRibbonViewerControl1);
            Name = "frmReport";
            Text = "frmReport";
            Load += frmReport_Load;
            ResumeLayout(false);
        }

        #endregion

        private Stimulsoft.Report.Viewer.StiRibbonViewerControl stiRibbonViewerControl1;
    }
}