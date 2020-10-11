using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Diagnostics;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Audio_Recorder
{
    class AudioFile
    {
        public bool recordingStatus { get; set; }
        public MediaCapture mediaCapture { get; set; }
        public LowLagMediaRecording _mediaRecording { get; set; }

        public AudioFile()
        {
            this.recordingStatus = false;
            this.mediaCapture = new MediaCapture();
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        }

        public void StartRecording()
        {
            this.recordingStatus = true;
        }

        public void StopRecording()
        {
            this.recordingStatus = false;
        }
    }

    public class AudioFileViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { }; 

        private bool _recordingStatus;
        public string recordingPrompt { get { return this._recordingStatus ? "record" : "stop"; } set { this._recordingStatus = !this._recordingStatus; this.OnPropertyChanged(); } }
        public AudioFileViewModel()
        {
            this._recordingStatus = false;
            this.recordingPrompt = "Record";
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
