
namespace hw9
{
    partial class FormCrawl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBeginCrawl = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.listViewTrue = new System.Windows.Forms.ListView();
            this.listViewFalse = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBeginCrawl
            // 
            this.buttonBeginCrawl.Location = new System.Drawing.Point(681, 17);
            this.buttonBeginCrawl.Name = "buttonBeginCrawl";
            this.buttonBeginCrawl.Size = new System.Drawing.Size(140, 50);
            this.buttonBeginCrawl.TabIndex = 0;
            this.buttonBeginCrawl.Text = "开始爬虫";
            this.buttonBeginCrawl.UseVisualStyleBackColor = true;
            this.buttonBeginCrawl.Click += new System.EventHandler(this.buttonBeginCrawl_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUrl.Location = new System.Drawing.Point(76, 25);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(578, 34);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.TextChanged += new System.EventHandler(this.textBoxUrl_TextChanged);
            // 
            // listViewTrue
            // 
            this.listViewTrue.HideSelection = false;
            this.listViewTrue.Location = new System.Drawing.Point(38, 65);
            this.listViewTrue.Name = "listViewTrue";
            this.listViewTrue.Size = new System.Drawing.Size(727, 344);
            this.listViewTrue.TabIndex = 2;
            this.listViewTrue.UseCompatibleStateImageBehavior = false;
            // 
            // listViewFalse
            // 
            this.listViewFalse.HideSelection = false;
            this.listViewFalse.Location = new System.Drawing.Point(38, 415);
            this.listViewFalse.Name = "listViewFalse";
            this.listViewFalse.Size = new System.Drawing.Size(727, 46);
            this.listViewFalse.TabIndex = 3;
            this.listViewFalse.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "url";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormCrawl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewFalse);
            this.Controls.Add(this.listViewTrue);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonBeginCrawl);
            this.Name = "FormCrawl";
            this.Text = "爬虫";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBeginCrawl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.ListView listViewTrue;
        private System.Windows.Forms.ListView listViewFalse;
        private System.Windows.Forms.Label label1;
    }
}

