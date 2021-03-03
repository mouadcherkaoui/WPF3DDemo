using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf3DPlayer.Common;
using Wpf3DPlayer.Models;

namespace Wpf3DPlayer.Viewmodels
{
    public class MediaListViewModel : ObservableBase
    {
        private MediaElement mediaElement;
        private Timer timer;
        private decimal volumeValue;
        private decimal timelineValue;
        private decimal speedRatioValue;
        OpenFileDialog fileDialog;
        public MediaListViewModel()
        {
            mediaItems = new ObservableCollection<MediaItem>();
            mediaElement = new MediaElement();
            mediaElement.MediaOpened += MediaElement_MediaOpened;
            
            fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void MediaElement_MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineValue;

            // Overloaded constructor takes the arguments days, hours, minutes, seconds, milliseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            mediaElement.Position = ts;
        }

        private void InitializePropertyValues()
        {
            // Set the media's starting Volume and SpeedRatio to the current value of the
            // their respective slider controls.
            mediaElement.Volume = (double)volumeValue;
            mediaElement.SpeedRatio = (double)speedRatioValue;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.WriteLine(e.SignalTime);
        }

        #region public properties
        private MediaItem currentItem;
        public MediaItem CurrentItem
        {
            get => currentItem;
            set => SetProperty(ref currentItem, value);
        }

        private ObservableCollection<MediaItem> mediaItems;
        public ObservableCollection<MediaItem> MediaItems
        {
            get => mediaItems;
            set => SetProperty(ref mediaItems, value);
        }
        #endregion

        #region commands

        public ICommand SelectItemCommand
            => new RelayCommand<MediaItem>(i => SetCurrentItem(i), (i) => true);
        private void SetCurrentItem(MediaItem item)
        {
            CurrentItem = item;
            mediaElement.Source = new Uri(currentItem.Path);
        }

        public ICommand PlayCommand
            => new RelayCommand<MediaElement>(m =>
            {
                m.Play();
                timer.Start();
            },
                m => m.Source != null);
        public ICommand PauseCommand
            => new RelayCommand<MediaElement>(m =>
                {
                    m.Pause();
                    timer.Stop();
                },
                m => m.CanPause);
        public ICommand StopCommand
            => new RelayCommand<MediaElement>(m =>
            {
                m.Stop();
            },
            m => m.CanPause);

        public ICommand OpenDialogCommand
            => new RelayCommand<FileDialog>(fd =>
            {

                var dialogResult = fileDialog.ShowDialog();
                if (dialogResult.HasValue && dialogResult.Value)
                {
                    var filesNames = fileDialog.FileNames;
                    foreach (var current in filesNames)
                    {
                        var splitedPath = current.Split('\\').ToList();
                        var name = splitedPath.Last();

                        var mediaItem = new MediaItem
                        {
                            Title = name,
                            Path = current
                        };
                        this.MediaItems.Add(mediaItem);
                        NotifyPropertyChanged(nameof(MediaItems));
                    }
                }
            }, fd => true);
        #endregion
    }
}
