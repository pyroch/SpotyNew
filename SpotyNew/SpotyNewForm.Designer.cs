
namespace SpotyNew
{
    partial class SpotyNewForm
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
            this.getTrackListButton = new System.Windows.Forms.Button();
            this.trackList = new System.Windows.Forms.ListView();
            this.currentUserId = new System.Windows.Forms.TextBox();
            this.currentUserIdLabel = new System.Windows.Forms.Label();
            this.playlistsAmount = new System.Windows.Forms.ComboBox();
            this.playlistsAmountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getTrackListButton
            // 
            this.getTrackListButton.Location = new System.Drawing.Point(475, 13);
            this.getTrackListButton.Name = "getTrackListButton";
            this.getTrackListButton.Size = new System.Drawing.Size(75, 23);
            this.getTrackListButton.TabIndex = 0;
            this.getTrackListButton.Text = "Get Tracks";
            this.getTrackListButton.UseVisualStyleBackColor = true;
            this.getTrackListButton.Click += new System.EventHandler(this.getTrackListButton_Click);
            // 
            // trackList
            // 
            this.trackList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trackList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.trackList.HideSelection = false;
            this.trackList.Location = new System.Drawing.Point(12, 42);
            this.trackList.MultiSelect = false;
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(538, 396);
            this.trackList.TabIndex = 2;
            this.trackList.TabStop = false;
            this.trackList.UseCompatibleStateImageBehavior = false;
            this.trackList.View = System.Windows.Forms.View.Details;
            // 
            // currentUserId
            // 
            this.currentUserId.Location = new System.Drawing.Point(86, 15);
            this.currentUserId.Name = "currentUserId";
            this.currentUserId.Size = new System.Drawing.Size(100, 20);
            this.currentUserId.TabIndex = 3;
            // 
            // currentUserIdLabel
            // 
            this.currentUserIdLabel.AutoSize = true;
            this.currentUserIdLabel.Location = new System.Drawing.Point(12, 18);
            this.currentUserIdLabel.Name = "currentUserIdLabel";
            this.currentUserIdLabel.Size = new System.Drawing.Size(67, 13);
            this.currentUserIdLabel.TabIndex = 4;
            this.currentUserIdLabel.Text = "Current user:";
            // 
            // playlistsAmount
            // 
            this.playlistsAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playlistsAmount.FormattingEnabled = true;
            this.playlistsAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.playlistsAmount.Location = new System.Drawing.Point(296, 14);
            this.playlistsAmount.Name = "playlistsAmount";
            this.playlistsAmount.Size = new System.Drawing.Size(31, 21);
            this.playlistsAmount.TabIndex = 5;
            // 
            // playlistsAmountLabel
            // 
            this.playlistsAmountLabel.AutoSize = true;
            this.playlistsAmountLabel.Location = new System.Drawing.Point(192, 18);
            this.playlistsAmountLabel.Name = "playlistsAmountLabel";
            this.playlistsAmountLabel.Size = new System.Drawing.Size(98, 13);
            this.playlistsAmountLabel.TabIndex = 6;
            this.playlistsAmountLabel.Text = "Amount of Playlists:";
            // 
            // SpotyNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 450);
            this.Controls.Add(this.playlistsAmountLabel);
            this.Controls.Add(this.playlistsAmount);
            this.Controls.Add(this.currentUserIdLabel);
            this.Controls.Add(this.currentUserId);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.getTrackListButton);
            this.Name = "SpotyNewForm";
            this.Text = "SpotyNew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTrackListButton;
        private System.Windows.Forms.ListView trackList;
        private System.Windows.Forms.TextBox currentUserId;
        private System.Windows.Forms.Label currentUserIdLabel;
        private System.Windows.Forms.ComboBox playlistsAmount;
        private System.Windows.Forms.Label playlistsAmountLabel;
    }
}

