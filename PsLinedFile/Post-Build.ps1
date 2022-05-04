param(
    [Parameter()] $ProjectName,
[Parameter()] $ConfigurationName,
[Parameter()] $TargetDir
    )

#Copy 'PsLinedFile.dll' '.\PsLinedFile' -Force -Verbose
#Copy 'FileHelpers.dll' '.\PsLinedFile' -Force -Verbose
Get-ChildItem| where {$_.Mode -eq '-a----'} | copy -Destination '.\PsExcelData' -Force -Verbose