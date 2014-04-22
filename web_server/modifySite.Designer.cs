namespace web_server
{
    partial class modifySite
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
            this.sitelist = new System.Windows.Forms.ListView();
            this.modify = new System.Windows.Forms.Button();
            this.delete_site = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sitelist
            // 
            this.sitelist.Location = new System.Drawing.Point(0, 0);
            this.sitelist.Name = "sitelist";
            this.sitelist.Size = new System.Drawing.Size(370, 254);
            this.sitelist.TabIndex = 0;
            this.sitelist.UseCompatibleStateImageBehavior = false;
            this.sitelist.View = System.Windows.Forms.View.Details;
            // 
            // modify
            // 
            this.modify.Location = new System.Drawing.Point(376, 12);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(75, 23);
            this.modify.TabIndex = 1;
            this.modify.Text = "修改属性";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.modify_Click);
            // 
            // delete_site
            // 
            this.delete_site.Location = new System.Drawing.Point(376, 62);
            this.delete_site.Name = "delete_site";
            this.delete_site.Size = new System.Drawing.Size(75, 23);
            this.delete_site.TabIndex = 2;
            this.delete_site.Text = "删除站点";
            this.delete_site.UseVisualStyleBackColor = true;
            this.delete_site.Click += new System.EventHandler(this.delete_site_Click);
            // 
            // modifySite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 254);
            this.Controls.Add(this.delete_site);
            this.Controls.Add(this.modify);
            this.Controls.Add(this.sitelist);
            this.Name = "modifySite";
            this.Text = "modifySite";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView sitelist;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.Button delete_site;
    }
}