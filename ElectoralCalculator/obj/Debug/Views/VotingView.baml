   M S B A M L   `   `   `  ����N  JElectoralCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ElectoralCalculator.ViewsElectoralCalculator.Views  5      *    $ElectoralCalculator.Views.VotingView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ElectoralCalculator.Views     5      .��5	      � -   5        $
��grid��5	        � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  $��10q�6   $��Center=�6      AutoGenerateColumns .  ��6`   ��  �� Path$ 
Candidates�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Id��,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Id��5   _      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� $ ID�6k     5      -   5        Name�� . $
 Name��5   d   $ * 6r    6F   �� $
 Name�6r     5      -   5        	Party�� . $ Party��5   f   $ * 6u    6G   �� $ Party�6u   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      -   5        
Select��$ Select��5   \   $ * 6l    69   �� $ IsSelect�6x   5      �� 5   
   -   5        $
��vote��5      $
��Vote��6   $��1��6,   $��10q�69   ��6E   �� *VotingCommand+6i   5      5      