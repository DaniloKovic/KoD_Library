   M S B A M L   `   `   `  ???? P  LKoD_Library_HCI_Core6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:KoD_Library_HCI_Core6.ViewsKoD_Library_HCI_Core6.Views  1    +KoD_Library_HCI_Core6.Views.BookDetailsPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:KoD_Library_HCI_Core6.Views       N? Title$  BookDetailsPage?? ? 	Resources  ?? 
TargetType ?? Property ?? Value??%G  '??       '?? ?     '?? ?     '?? ?     ?? " ??.???  ? ??$ 6q???  ? ??
 ? ? ???  ? ??
 ???????  ? ??$ 28????  ? ??$ 28????  ?@d?	IsChecked$ FalseY???  ? {?$
 True???? " ??.???  ? ??$ 3q??? " ??.???  ? ??$ 3q??? " ??.???  ? ??$ 3q?.??? .+??? -    ??Name$ 
gbBookInfo??$??Nova Knjiga??$??10,10,10,10q?$??18(?$??12)?$??3q?
???   ?$??Visible=??  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$ Vertical=?.???? -    ??Name$ 
stBookInfo??$??20,15,20,15q? ?? Orientation$ Vertical=?.+?]? $??	0,10,10,0q?$??Stretch=?.+??? $
??Left=?.??	Naslov:?? -   $??tbNaslovKnjige??$??Stretch=??? $ 
Horizontal=?$??0,10,0,0q?.+??? .??Godina izdanja:?? -   $??tbGodinaIzdanja??$	??132???? $ Vertical=?$??	0,10,10,0q?.+??? .??Opis:?? -   $??tbOpis??	 ?? TextWrapping$
	 Wrap=?$??66???? $ Vertical=?$	??115??$??0,10,0,0q?.+??? .??Autor/Autori:?? $ 
Horizontal=?.+??? $ 
Horizontal=?$
??Left=?.+??? -   $??cbAutori??
 ?? 
IsEditable$

 True??$	??275??$??0,0,10,0q?$
??Left=??? -   $??btnAddToCbAutori??$??32??$??32??.???? $[??UC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\plus.png???? $ 
Horizontal=?$??	130,0,0,0q?$??Right=?.+??? -   $??chbMultipleAutor???? -	   $??cbSelectedAutori??${?False??$	??260???? $ 
Horizontal=?$??0,10,0,0q?.+??? -
    ??Name$ btnAddNewAutor??$??
Novi autor??$	??180?? ? ToolTip _? $??Unesite novog autora???? -    ??Name$ tbNoviAutor??$	??260??$??10,0,0,0q??? $ Vertical=?$??0,5,0,0q?.+??? .??Žanr/Žanrovi:?? $ 
Horizontal=?.+??? $ 
Horizontal=?$
??Left=?.+??? -   $??	cbZanrovi??$

 True??$	??275??$??0,0,10,0q??? -   $??btnAddToCbZanrovi??$??32??$??32??.???? $[??UC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\plus.png???? $ 
Horizontal=?$??	130,0,0,0q?$??Right=?.+??? -   $??chbMultipleZanr???? -   $??cbSelectedZanrovi??${?False??$	??260???? $ 
Horizontal=?$??0,10,0,0q?.+??? -   $ btnAddNewZanr??$??
Novi žanr??$	??180?? _? $??Unesite novi žanr???? -   $ 
tbNoviZanr??$	??260??$??10,0,0,0q??? $ 
Horizontal=?$??0,15,0,0q?.+??? -    ??Name$ 
lbKolicina??.??
Količina:?? -   $ 
tbKolicina??$??32??$??60???? $ 
Horizontal=?$??0,10,0,0q?.+??? -   $ lbDostupnaKolicina??.??Dostupna Količina:?? -   $ tbDostupnaKolicina??$??32??$??60??${?False???? -   $ spDostupnost??$ 
Horizontal=?$y?Visible=?$
??Left=?.+??? -   $ lbDostupnost??$??20,0,0,0q?.??Dostupnost Knjige?? -    ??Name$ chbDostupnost???? $ 
Horizontal=?$??	0,10,10,0q?$
??Left=?.+??? -   $??btnAddOrUpdateBook??$??Dodaj novu knjigu??$	??Top=?$??40??$	??215??