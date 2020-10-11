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

    class AudioFileViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public AudioFile _audioFile { get; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string _recordingStatus { 
            get { 
                    if (this._audioFile.recordingStatus)
                    {
                        return "recording";
                    } else
                    {
                        return "not recording";
                    }
            } 
        }
        
        public AudioFileViewModel()
        {
            this._audioFile = new AudioFile(); 
        }
    }
}
