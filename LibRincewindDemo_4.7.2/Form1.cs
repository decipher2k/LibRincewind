using LibRincewind_4._7._2;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace LibRincewindDemo_4._7._2
{
  public class Form1 : Form
  {
    private CRincewind libRincewind = (CRincewind) null;
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button button1;
    private Label label4;
    private Label label5;
    private Label label6;
    private Button button2;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;

    public Form1()
    {
      this.InitializeComponent();
      this.libRincewind = new CRincewind(AppDomain.CurrentDomain.BaseDirectory + "\\LibRincewindPlugin_Blowfish_4.7.2.dll", 16);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      CCryptData ccryptData = this.libRincewind.encryptCCD(this.textBox3.Text, this.textBox1.Text, this.textBox2.Text);
      this.textBox4.Text = ccryptData.CryptedData;
      this.textBox5.Text = ccryptData.Key;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      CRincewind libRincewind = this.libRincewind;
      CCryptData cryptData = new CCryptData();
      cryptData.CryptedData = this.textBox4.Text;
      cryptData.Key = this.textBox5.Text;
      cryptData.IV = this.libRincewind.IV;

     

      string text1 = this.textBox1.Text;
      string text2 = this.textBox2.Text;
      this.textBox6.Text = libRincewind.decryptCCD(cryptData, text1, text2);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.button1 = new Button();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.button2 = new Button();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.textBox6 = new TextBox();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(29, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(130, 25);
      this.label1.TabIndex = 0;
      this.label1.Text = "Password 1:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(29, 59);
      this.label2.Name = "label2";
      this.label2.Size = new Size(130, 25);
      this.label2.TabIndex = 1;
      this.label2.Text = "Password 2:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(29, 94);
      this.label3.Name = "label3";
      this.label3.Size = new Size(175, 25);
      this.label3.TabIndex = 2;
      this.label3.Text = "String to encrypt:";
      this.button1.Location = new Point(497, 135);
      this.button1.Name = "button1";
      this.button1.Size = new Size(125, 38);
      this.button1.TabIndex = 3;
      this.button1.Text = "Encrypt";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(41, 194);
      this.label4.Name = "label4";
      this.label4.Size = new Size(115, 25);
      this.label4.TabIndex = 4;
      this.label4.Text = "Encrypted:";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(41, 229);
      this.label5.Name = "label5";
      this.label5.Size = new Size(163, 25);
      this.label5.TabIndex = 5;
      this.label5.Text = "Encryption Key:";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(41, 261);
      this.label6.Name = "label6";
      this.label6.Size = new Size(157, 25);
      this.label6.TabIndex = 6;
      this.label6.Text = "Decrypted text:";
      this.button2.Location = new Point(497, 299);
      this.button2.Name = "button2";
      this.button2.Size = new Size(125, 38);
      this.button2.TabIndex = 7;
      this.button2.Text = "Decrypt";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.textBox1.Location = new Point(222, 24);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(400, 31);
      this.textBox1.TabIndex = 8;
      this.textBox1.UseSystemPasswordChar = true;
      this.textBox2.Location = new Point(224, 61);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(400, 31);
      this.textBox2.TabIndex = 9;
      this.textBox2.UseSystemPasswordChar = true;
      this.textBox3.Location = new Point(222, 98);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(400, 31);
      this.textBox3.TabIndex = 10;
      this.textBox4.Location = new Point(222, 188);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(400, 31);
      this.textBox4.TabIndex = 11;
      this.textBox5.Location = new Point(222, 225);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(400, 31);
      this.textBox5.TabIndex = 12;
      this.textBox6.Location = new Point(222, 262);
      this.textBox6.Name = "textBox6";
      this.textBox6.ReadOnly = true;
      this.textBox6.Size = new Size(400, 31);
      this.textBox6.TabIndex = 13;
      this.AutoScaleDimensions = new SizeF(12f, 25f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new Size(640, 350);
      this.Controls.Add((Control) this.textBox6);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Form1);
      this.Text = "LibRincewind Demo (c) 2023 Dennis M. Heine";
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
