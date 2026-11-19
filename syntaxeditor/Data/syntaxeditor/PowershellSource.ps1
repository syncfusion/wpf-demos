#*****************************************************************
#
#   Script Name:  dhcpBackup.ps1
#   Version:  1.0
#   Author:  Jason Carter
#   Date:  August 30,  2007
#
#   Description:  Used to backup DHCP logs from the DHCP server
#   to another storage device for archiving purposes.
#
#*****************************************************************
 
# Get Yestedays Date In Month, Day, Year format
$yesterday = ( Get-Date ( Get-Date ).AddDays(-1) -uformat %m%d%Y )
 
# Get the first 3 letters of the day name from yesterday
$logdate=( [string]( ( Get-Date ).AddDays(-1).DayofWeek ) ).SubString(0,3)
 
# Change path to DHCP log folder, copy yesterdays log file to backup location
Set-Location "C:\WINDOWS\System32\dhcp"
Copy-Item "DhcpSrvLog-$logdate.log" "D:\DHCPBACKUP"
 
# Rename log file with yesterdays date
Set-Location "D:\DHCPBACKUP"
Rename-Item "DhcpSrvLog-$logdate.log" "$yesterday.log"

param( [string]$orgfile, [string]$diffile, [string]$switch )

If ( $diffile -eq "" ) {
	Write-Host
	Write-Host "TxtComp.ps1,  Version 1.00"
	Write-Host "Compare 2 text files and display the differences"
	Write-Host
	Write-Host "Usage:  .\TXTCOMP.PS1  file1  file2  [ /ALL ]"
	Write-Host
	Write-Host "Where:  file1 and file2  are the files to be compared"
	Write-Host "        /ALL             display all lines, not just the differences"
	Write-Host
	Write-Host "Written by Rob van der Woude"
	Write-Host "http://www.robvanderwoude.com"
	Write-Host
}
Else
{
If ( $switch -eq "/ALL" ) 
{
		Compare-Object $( Get-Content $orgfile ) $( Get-Content $diffile ) -IncludeEqual
}
Else
  {
		Compare-Object $( Get-Content $orgfile ) $( Get-Content $diffile )
	}
}

# WMI query to list all properties and values of the Win32_Printer class
# This PowerShell script was generated using the WMI Code Generator, Version 1.30
# http://www.robvanderwoude.com/updates/wmigen.html

param( [string]$strComputer = "." )

$colItems = get-wmiobject -class "Win32_Printer" -namespace "root\CIMV2" -computername $strComputer

foreach ($objItem in $colItems) 
{
	write-host "Name                           :" $objItem.Name
	write-host "Default                        :" $objItem.Default
	write-host "Network                        :" $objItem.Network
	write-host "Port Name                      :" $objItem.PortName
	write-host "Driver Name                    :" $objItem.DriverName
	write-host "Server Name                    :" $objItem.ServerName
	write-host "Share Name                     :" $objItem.ShareName
	write-host
}

# array . ps1
$os = @(" linux " , " windows ")
$os += @(" mac ")
Write-Host $os [1] # print windows
Write-Host $os # print array values
Write-Host $os . Count # length of array

# assoc-array . ps1
$user =@
{
" frodeh " = " Frode Haug " ;
" ivarm " = " Ivar Moe "
}
$user += @ {" lailas " =" Laila Skiaker "}
Write-Host $user [" ivarm "] # print Ivar Moe
Write-Host @user # print array values
Write-Host $user . Keys # print array keys
Write-Host $user . Count # print length of array

# struct . ps1
$myhost = New-Object PSObject - Property `
@
{ os ="";
sw =@ ();
user =@ {}
}
$myhost . os = " linux "
$myhost . sw += @(" gcc " ," flex " ," vim ")
$myhost . user += @
{
" frodeh " =" Frode Haug " ;
" monicas "=" Monica Strand "
}
Write-Host $myhost . os
Write-Host $myhost . sw [2]
Write-Host $myhost . user [" monicas "]

# cli-args . ps1
Write-Host "I am " $MyInvocation . InvocationName `
" and have " $args . Count " arguments " `
" first is " $args [0]

# input-user . ps1
$something = Read-Host " Say something here "
Write-Host " you said " $something

Input From the Pipeline
# input-pipe . ps1
$something =" $input "
Write-Host " you said " $something

Input from System Commands
# i n p u t - c o m m a n d s . ps1
$name =( Get-WmiObject Win32_OperatingSystem ). Name
$kernel =( Get-WmiObject `
Win32_OperatingSystem $asdasda). Version
Write-Host "I am running on $name , version " `
" $kernel in $( Get-Location )"
Using $(expr) inside a string will treat it as an ad-h

#if 
if ( $args . Length -ne 1) {
Write-Host " usage : " `
$MyInvocation . InvocationName `
" < argument >"
}
#endif


# if-num-string . ps1
if ( $args . Count - ne 2) 
{
Write-Host " usage : " `
$MyInvocation . InvocationName `
" < argument > < argument >"
exit 0
}
 elseif ( $args [0] - gt $args [1]) 
 {
Write-Host $args [0] " larger than " $args [1]
} 
else 
{
Write-Host $args [0] " smaller than or " `
" equal to " $args [1]
}
if ( Test-Path $args [0]) 
{
if (!( Get-Item $args [0]). PSIsContainer ) 
{
Write-Host $args [0] " is a file "
}
}

# if-bool . ps1
if ((1 -eq 2) -and (1 - eq 1) -or (1 -eq 1))
 {
Write-Host " And has precedence "
} 
else 
{
Write-Host " Or has precedence "
}
# force OR precedence :
if ((1 -eq 2) -and ((1 -eq 1) -or (1 -eq 1)))
{
Write-Host " And has precedence "
} 
else 
{
Write-Host " Or has precedence "
}

# switch . ps1
$short = @ 
{
 yes ="y "; nope = "n" 
 }
$ans = Read-Host
switch ( $ans ) 
{
yes 
{
 Write-Host " yes " 
 }
nope 
{
 Write-Host " nope "; break 
 }
{ 
$short . ContainsKey (" $ans " )
} `
{
 Write-Host $short [ $ans ] 
 }
default 
{
 Write-Host "$ans `??? "
 }
}

# where . ps1
Get-ChildItem | Where-Object {$_ . Length - gt 1 KB }

# for . ps1
for ($i =1; $i-le3 ;$i ++) 
{
Write-Host "$i "
}
# something more useful :
$file = Get-ChildItem
for ($i =0; $i-lt$file . Count ;$i ++) 
{
if (!( Get-Item $file [$i ]). PSIsContainer ) 
{
Write-Host $file [$i ]. Name " is a file "
} 
else 
{
Write-Host $file [$i ]. Name " is a directory "
}
}

ForEach ($i in 1..3) 
{
Write-Host "$i "
}

# while . ps1
while ($i - le 3) 
{
Write-Host $i
$i ++
}
# something more useful :
$file = Get-ChildItem
$i =0
while ($i - lt $file . Count ) 
{
if (!( Get-Item $file [$i ]). PSIsContainer ) 
{
Write-Host $file [$i ]. Name " is a file "
} 
else
{
Write-Host $file [$i ]. Name " is a directory "
}
$i ++
}

# regexp . ps1
$input | ForEach-Object 
{
if ($_ - match
" ˆ[ A-Za-z0-9 . _- ]+ @ ([ A-Za-z0-9 .-]+) $") 
{
Write-Host " Valid email " , $matches [0]
Write-Host " Domain is " , $matches [1]
} 
else 
{
Write-Host " Invalid email address !"
}
