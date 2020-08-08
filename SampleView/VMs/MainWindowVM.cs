using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using BaseVM;
namespace SampleView.VMs
{
   public class MainWindowVM:BaseViewModel
    {

        string openImageLoc = @"Icons\connected.png";
        string closeImageLoc = @"Icons\disconnected.png";
        string startImageLoc = @"Icons\play.png";
        string stopImageLoc = @"Icons\stop.png";
        string captureImageLoc = @"Icons\capture.png";

        private string openImagePath;

        public string OpenImagePath
        {
            get { return openImagePath; }
            set { openImagePath = value;
                OnPropertyChanged("OpenImagePath");
            }
        }

        private string startImagePath;

        public string StartImagePath
        {
            get { return startImagePath; }
            set
            {
                startImagePath = value;
                OnPropertyChanged("StartImagePath");
            }
        }

        private string captureImagePath;

        public string CaptureImagePath
        {
            get { return captureImagePath; }
            set
            {
                captureImagePath = value;
                OnPropertyChanged("CaptureImagePath");
            }
        }

        private string openTxt;

        public string OpenTxt
        {
            get { return openTxt; }
            set
            {
                openTxt = value;
                OnPropertyChanged("OpenTxt");
            }
        }

        private string startTxt;

        public string StartTxt
        {
            get { return startTxt; }
            set
            {
                startTxt = value;
                OnPropertyChanged("StartTxt");
            }
        }

        private string captureTxt;

        public string CaptureTxt
        {
            get { return captureTxt; }
            set
            {
                captureTxt = value;
                OnPropertyChanged("CaptureTxt");
            }
        }

        public ICommand OpenCmd { get; set; }
        public ICommand StartCmd { get; set; }
        public ICommand CaptureCmd { get; set; }

        bool isOpen = false;
        bool isStart = false;
        bool isCapture = false;
        public MainWindowVM()
        {
            OpenCmd = new RelayCommand(Open, CanOpen); 
            StartCmd = new RelayCommand(Start, CanStart);
            CaptureCmd = new RelayCommand(Capture, CanCapture);
            OpenTxt = "Open";
            StartTxt = "Start";
            CaptureTxt = "Capture";
            OpenImagePath =  openImageLoc.GetAbsolutePath();
            StartImagePath = startImageLoc.GetAbsolutePath();
            CaptureImagePath = captureImageLoc.GetAbsolutePath();
        }

        private void Open(object obj)
        {
            if (!isOpen)
            {
                OpenImagePath = closeImageLoc.GetAbsolutePath();
                OpenTxt = "Close";
                isOpen = true;
            }
            else
            {
                OpenImagePath = openImageLoc.GetAbsolutePath();
                OpenTxt = "Open";
                isOpen = false;
            }
        }

        private bool CanOpen(object obj)
        {
            return true;
        }

        private void Start(object obj)
        {
            if (!isStart)
            {
                StartImagePath = stopImageLoc.GetAbsolutePath();
                StartTxt = "Stop";
                isStart = true;
            }
            else
            {
                StartImagePath = startImageLoc.GetAbsolutePath();
                StartTxt = "Start";
                isStart = false;
            }
        }

        private bool CanStart(object obj)
        {
            return true;
        }


        private void Capture(object obj)
        {
            if (!isCapture)
            {
                CaptureImagePath = captureImageLoc.GetAbsolutePath();
                CaptureTxt = "Capture";
                isCapture = true;
            }
            else
            {
                CaptureTxt = "Resume";
                isCapture = false;
            }
        }

        private bool CanCapture(object obj)
        {
            return true;
        }


    }

    public static class AbsolutePath
    {
        public static string GetAbsolutePath(this string relativePath)
        {
           return Path.Combine(new FileInfo( System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName, relativePath);
        }
    }
}
