   M S B A M L   `   `   `  ����K  GMoviesDB_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MoviesDB_ManagerMoviesDB_Manager  5   	   )    #MoviesDB_Manager.AddMovieToDirector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MoviesDB_Manager     5   	   -   5          � Title$  Add Movie To Director��5   	   $	��220��6'   $	��360��64    � 
ResizeMode$ NoResize=�6@   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��3��6   $
��Left=�5      $��	UltraBold"�6/   $��26��6F   $��2��6R   $	��Top=�6f   .��6~   	Director:6�   �� 5    
   -   5        $��directorsComboBox��5       $��1��6,   $��2��69   $��3��6I   �� 5!   
   $��2��6   $��3��6   $��1��6-   $��Center=�5"      $��	UltraBold"�61   .��6H   Movie:6P   �� 5#   
   $��4��6   $��0��6   $��3��6-   .��6A   Title:6I   �� 5$   
   -   5        $��titleTextBox��5$      $��4��6&   $��1��63   $��2��6C   $��20��5%      �� 5&   
   -   5        $��moviesComboBox��5&      $��4��6)   $��4��66   $��2��6F   ${�False��5'      �� 5(   
   -   5        $��checkBox��5(      $��3��6#   $��4��60   $��2��6@   .��5)   ?   Choose exist6M   �� 5*   
   -   5        $��6��5*      $��3��6   .��6@   Add6E   5+      5,      