   M S B A M L   `   `   `  ����K  GMoviesDB_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MoviesDB_ManagerMoviesDB_Manager  5   	       MoviesDB_Manager.AddActor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MoviesDB_Manager     5   	     � Title$  Add Actor / Actress��5   	   $	��238��6%   $	��220��62    � 
ResizeMode$ NoResize=�6>   .��5	      � -   5        $��addActorPanel��5	       � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5      $	��110 �6   �� 5      $��70 �6   .+�5   
   �� $��1��6   .��6   First name:6*   �� 5   
   $��2��6   .��6   
Last Name:6)   �� 5   
   $��3��6   .��6   Birth Year:6*   �� 5   
   $��4��6   .��6   	Gender:6&   �� 5   
   -   5        $��firstNameTextBox��5      $��20��6*   $��1��66   $��1��6C   �� 5   
   -   5        $��lastNameTextBox��5      $��20��6)   $��2��65   $��1��6B   �� 5   
   -   5        $��yearBornTextBox��5      $��20��6)   $��3��65   $��1��6B   	� 5   
   -   5        $��maleRadioButton��5      $��4��6-   $��1��6:   $
��Male��6J   $��Center=�5      	� 5    
   -   5        $��femaleRadioButton��5       $��4��6/   $��1��6<   $��Female��6L   $��Right=�5!      $��Center=�62   �� 5"   
   -   5        $��	addButton��5"      $��5��6"   $��1��6/   .��5#   #   Add6(   5$      5%      