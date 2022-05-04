param(
    [Parameter()] $ProjectName,
[Parameter()] $ConfigurationName,
[Parameter()] $TargetDir
    )

Get-ChildItem| where {$_.Mode -eq '-a----'} | copy -Destination '.\PsExcelData' -Force -Verbose