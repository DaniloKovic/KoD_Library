   M S B A M L   `   `   `  ???? P  LKoD_Library_HCI_Core6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KoD_Library_HCI_Core6.Views.Pages!KoD_Library_HCI_Core6.Views.Pages  5    /KoD_Library_HCI_Core6.Views.Pages.MyAccountPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:KoD_Library_HCI_Core6.Views.Pages       N? Title$  MyAccountPage?? ? 	Resources  ?? 
TargetType ?? Property ?? Value??%L  '??       '?? m     '?? ?     ?? " ??innerStackPanelStyle??.???  ?@??Orientation$ 
Horizontal=???  ? ??$ 	10,10,0,0q??? " ??.???  ? ??$	 260????  ?@??
IsReadOnly$
 True????  ? ??$ 4q??? " ??.???  ? ??$ 4q???  ? ??$ 40????  ? ??$	 260????  ? ??$ 22(?.??? .+??? -    ??Name$ gbMyAccountInfo??$??	Moj nalog??$??10,10,10,10q?$??20(?$??3q?
???   ?.??]? -    ]?Name$ spMainSP??$??10,10,10,10q?.+??? -    ??Name$ 
spInnerSP1?? ?? Orientation$ Vertical=?$	??450??$??0,0,0,0q?.+??? .+??? .??Ime i prezime:?? -   	 ??Name$	 tbImePrezime??$??10,0,0,0q??? .+??? .??Korisničko ime:?? -   $	 tbKorisnickoIme??$??1,0,0,0q??? .+??? .??Broj telefona:?? -   $	 tbBrojTelefona??$??17,0,0,0q??? .+??? .??	E-mail:?? -   $	 tbEmail??$	??334???? .+??? .??Datum registracije:?? -   $	 tbDatumRegistracije??$	??229???? -	   $ spBrIznajmljenihK??.+??? .??$"Trenutni broj iznajmljenih knjiga:?? -
   $	 tbTrenutniBroj??$	??108???? -   $ spUkupanBrIznajmljenihK??.+??? .??" Ukupan broj iznajmljenih knjiga:?? -   $	 tbUkupniBroj??$	??108??$??4,0,0,0q??? -   $ 	spLozinke??$ Vertical=?$??0,0,10,0q?.+??? -   $ 	spLozinka??$ Vertical=?.+??? $??0,5,0,0q?.+??? .??
Lozinka:? .+?G? -   
 G?Name$
 	pbLozinka?? G? PasswordChar$ *??$	??323??${?False??$??4q?
???  ???? -   $	 pbLozinkaText??$	??323??$y?	Collapsed=??? -   $??cbPrikaziLozinku??$??10q?$??Stretch=?$??Center=??? -    ??Name$ btnPromjenaLozinke??$	??323??$
??Left=?$??	81,10,0,0q?.??Promjena lozinke?? -   $ spPromjenaLozinke??$ Vertical=?$y?	Collapsed=?$??10,5,0,0q?.+??? $??0,10,0,0q?.+??? $??Nova lozinka:???? -   $	 tbNovaLozinka??$??17,0,0,0q? ?? 
IsReadOnly$ False???? $??0,10,0,0q?.+??? .??Potvrdi lozinku:?? -   $	 tbPotvrdiLozinku??$ False???? -   $ btnPotvrdiPromjenu??$	??260??$
??Left=?$??
145,10,0,0q?.??	Potvrdi?? -   $ 
spInnerSP2??$??0,0,0,0q?$ Vertical=?$??Right=?$	??Top=?$y?Visible=?.+??? -   $ spImage??$??Right=?.+??? $_??YC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\settings.png??$	??160??$	??260???? -   $ spTemplateChange??$ Vertical=?$??Right=?$	??Top=?$??	10,60,0,0q?.+??? $??Right=?$
??Bold"?.??Izaberi templejt?? $ 
Horizontal=?$??Right=?$??Center=?.+??? -   $ btnTemplate1??   RoundButton#??[  
???????? -   $ btnTemplate2??#??[  
?????_??? -   $ btnTemplate3??#??[  
???  ???? -   $ spLanguageChange??$ Vertical=?$??	10,60,0,0q?$??Right=?$	??Top=?.+??? $??Right=?$
??Bold"?.??Izaberi jezik?? $ 
Horizontal=?$??Right=?$??Center=?.+??? -   $ btnSrb??$	??SRB??  LanguageButton#??[ $??Center=?$??5,5,0,5q??? -   $ btnEng??$	??ENG??#??[ $??Center=?$??5,5,0,5q?