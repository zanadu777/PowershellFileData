param(
    [Parameter()] $ProjectName,
[Parameter()] $ConfigurationName,
[Parameter()] $TargetDir
    )

Copy 'PsCsv.dll' '.\PsCsv' -Force -Verbose
Get-ChildItem| where {$_.Mode -eq '-a----'} | copy -Destination '.\PsCsv' -Force -Verbose