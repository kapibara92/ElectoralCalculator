   M S B A M L   `   `   `  ����N  JElectoralCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ElectoralCalculator.ViewsElectoralCalculator.Views  5      )    #ElectoralCalculator.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ElectoralCalculator.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��2* �6   6,   .+�5   
   �� $
��Name��6   $��10q�6    $��Right=�6,   $��Center=�6H   6e   �� 5   
   $��Surname��6   $��10q�6#   $��1��6/   $��Right=�6<   $��Center=�6X   6u   �� 5   
   $��Pesel��6   $��10q�6!   $��2��6-   $��Right=�6:   $��Center=�6V   6s   �� 5   
   -   5        $
��Name��5      $��1��6   $��10q�6.   ��6:   �� *Name+ �� Mode$ OneWayToSource=�6g   �� 5   
   -   5        $��Surname��5      $��1��6!   $��1��61   $��10q�6>   ��6J   �� *	Surname+$ OneWayToSource=�6z   �� 5   
   -   5        $��Login��5      $��1��6   $��3��6.   $��Login��6;   $��10q�6K   ��6W   �� *VotingViewCommand+6   �� 5   
   -   5        $��Pesel��5      $��1��6   $��2��6/   $��10q�6<   ��6H   �� *Pesel+$ OneWayToSource=�6v   5      5      