﻿using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotyNew
{
    public partial class SpotyNewForm : Form
    {
        public static SpotifyClient _spotifyClient;

        BackgroundWorker worker;

        public SpotyNewForm()
        {
            InitializeComponent();
            Init();
            AuthInit();
        }

        private void Init()
        {
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "c1";
            trackList.Columns.Add(header);
            trackList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            trackList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=
                       new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private async Task AuthInit()
        {
            _spotifyClient = await Spotify.Auth.GetAuth();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var runGetTrackList = Spotify.TrackList.GetTrackListTuple(_spotifyClient, 1, currentUserId.Text);//// 1 is amount of playlists
            if (runGetTrackList == null)
            {
                MessageBox.Show("Can't get track list. Maybe internet offline or Spotify is down?.");
                return;
            }
            e.Result = runGetTrackList;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                var runGetTrackList = (List<Tuple<string, string, DateTime>>)e.Result;
                var sortedByDate = runGetTrackList.OrderByDescending(x => x.Item3);
                trackList.Items.Clear();
                foreach (var x in sortedByDate)
                {
                    trackList.Items.Add(x.Item1 + " - " + x.Item2 + ", " + x.Item3.ToString("dd/MM/yyyy"));
                }
            }
        }

        private void getTrackListButton_Click(object sender, EventArgs e)
        {
            try
            {
                worker.RunWorkerAsync();
            }
            catch
            {
                MessageBox.Show("Track List is not reachable.");
            }
        }
    }
}
