   M S B A M L   `   `   `  ����C  ?3DPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Wpf3DPlayerWpf3DPlayer  5   	   7 clr-namespace:Wpf3DPlayer.ModelsWpf3DPlayer.Models  5   	   ?$clr-namespace:Wpf3DPlayer.ViewmodelsWpf3DPlayer.Viewmodels  5   	       Wpf3DPlayer.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Wpf3DPlayer     5   	   3models clr-namespace:Wpf3DPlayer.Models     5   	   ;
viewmodels$clr-namespace:Wpf3DPlayer.Viewmodels     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � DataContext 5      /   )Wpf3DPlayer.Viewmodels.MediaListViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��8* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��6* �6   �� 5      $��* �6   .+�5   
   '� -   5         '�Name$ itemsListViewport��5      $��0��60   $��1��6@   $
}�True��6M    '� Camera 5      =� 5       � Position$ 0, 0, 41�6$   .x�5      3  -System.Windows.Media.Media3D.ModelUIElement3D  5      5  /System.Windows.Media.Media3D.Viewport2DVisual3D  5         Material 5'      u� 5(         IsVisualHostMaterial$
 True��6*   	 u� Brush
	 �����6Y   
   Geometry
 5*      k� 5+       k� 	Positions �    k� TextureCoordinates �    k� TriangleIndices �     5,   B      Visual. 5.      �� -   5         ��Name$ 	itemsList��5/      
����  �$��Center=�52      $��Center=�53      ��51      �� *
MediaItems+��54      �� 55      .R�56   "   A� 57      59      5:      g� 5;       g� Content 5<      t� 5=       �� Color$ 	#FFFFFFFF��6+    t� 	Direction$ 0,0,-15�6=   5?      5@      '� 5A   
   -   5        $ currentView��5A      $��1��6*   $��1��6:   5C      � 5D   
   $��2��6   $��1��6    5E      �� 5F      $��* �6#   �� 5G      $��* �6#   �� 5H      $��* �6#   �� 5I      $��* �6#   �� 5J      $��* �6#   .+�5L      �� $��0��6   $��2��5M      $��
Open Files��5N   7   ��6   �� *OpenDialogCommand+5O      5P      5Q      5R      