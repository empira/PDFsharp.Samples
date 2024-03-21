# Downloads assets.

# This file downloads assets required to compile the PDFsharp/MigraDoc samples source codes.
# This file runs under PowerShell Core 7.0 or higher.

#Requires -Version 7
#Requires -PSEdition Core

# Get-ChildItem .\ -include bin,obj -Recurse | ForEach-Object ($_) { remove-item $_.fullname -Force -Recurse }

[string[]]$assetList = @(
    "pdfsharp/pdfsharp.zip"
    "migradoc/migradoc.zip"
    "pdfsharp-6.x/pdfsharp-6.x.zip"
    # Grammar by example archive => Move to PDFsharp.Lab
    # "archives/grammar-by-example/GBE.zip"
    "archives/samples-1.5/samples-1.5.zip"
)

$source = "https://assets.pdfsharp.net/"
$destination = "$PSScriptRoot/../assets/"

if (test-path -PathType container $destination) {
    Remove-Item -LiteralPath $destination -Force -Recurse
}
New-Item -ItemType Directory -Path $destination

# Download assets version.
$url = $source + ".assets-version"
$dest = $destination + ".assets-version"
Invoke-WebRequest $url -OutFile $dest

foreach ($asset in $assetList) {
    $url = $source + $asset
    $dest = $destination + $asset

    $folder = [IO.Path]::GetDirectoryName($dest)
    New-Item -ItemType Directory -Path $folder -Force

    Invoke-WebRequest $url -OutFile $dest

    $idx = $asset.LastIndexOf("/")
    $assetFolder = $asset.Substring(0, $idx)
    # $zip = $asset.Substring($idx + 1)
    Expand-Archive "$destination/$asset" -DestinationPath "$destination/$assetFolder" -Force
    if ($True -or $LASTEXITCODE -eq 0) {
        Remove-Item "$destination/$asset"
        # Not all ZIP files contain compress.ps1. Suppress error messages.
        Remove-Item "$destination/$assetFolder/compress.ps1" -ErrorAction Ignore
    }
}
