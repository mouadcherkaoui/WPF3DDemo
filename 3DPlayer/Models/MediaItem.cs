using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using Wpf3DPlayer.Common;

namespace Wpf3DPlayer.Models
{
    public class MediaItem : ObservableBase
    {
        private string title;
        public string Title { 
            get => title; 
            set => SetProperty(ref title, value); 
        }

        private string path;
        public string Path { 
            get => path; 
            set => SetProperty(ref path, value); 
        }

        private decimal currentPosition;
        public decimal CurrentPosition { 
            get => currentPosition; 
            set => SetProperty(ref currentPosition, value); 
        }

        private TimeSpan duration;
        public TimeSpan Duration { 
            get => duration; 
            set => SetProperty(ref duration, value); 
        }

        private MediaState state;
        public MediaState State { 
            get => state; 
            set => SetProperty(ref state, value); 
        }
    }
}
