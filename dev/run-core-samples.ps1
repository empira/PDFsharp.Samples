# Run Core samples

# This file runs the Core samples that use .NET 6.0.
# The samples should run under Windows, WSL2, and Linux.
# This file runs under PowerShell Core 7.0 or higher.

#Requires -Version 7
#Requires -PSEdition Core

[string[]]$assemblyList = @(
    # src/samples/src/PDFsharp/src/PdfRef2LicenseRemover/bin/Debug/net6.0/PdfRef2LicenseRemover.exe
    # src/samples/src/PDFsharp/src/UAFeatures/bin/Debug/net6.0/UAFeatures.exe

    "src/samples/src/MigraDoc/src/HelloMigraDoc/bin/Debug/net6.0/HelloMigraDoc.dll"
    "src/samples/src/MigraDoc/src/HelloWorld/bin/Debug/net6.0/HelloWorld,MigraDoc.dll"
    "src/samples/src/PDFsharp/src/AES128/bin/Debug/net6.0/AES128.dll"
    "src/samples/src/PDFsharp/src/AES256/bin/Debug/net6.0/AES256.dll"
    "src/samples/src/PDFsharp/src/HelloWorld/bin/Debug/net6.0/HelloWorld,PDFsharp.dll"

    "src/samples-1.5/src/PDFsharp/src/Annotations/bin/Debug/net6.0/Annotation.dll"
    "src/samples-1.5/src/PDFsharp/src/Booklet/bin/Debug/net6.0/Booklet.dll"
    "src/samples-1.5/src/PDFsharp/src/Bookmarks/bin/Debug/net6.0/Bookmarks.dll"
    "src/samples-1.5/src/PDFsharp/src/Graphics/bin/Debug/net6.0/Graphics.dll"
    "src/samples-1.5/src/PDFsharp/src/HelloWorld/bin/Debug/net6.0/HelloWorld.dll"
    "src/samples-1.5/src/PDFsharp/src/TextLayout/bin/Debug/net6.0/TextLayout.dll"
    "src/samples-1.5/src/PDFsharp/src/XForms/bin/Debug/net6.0/XForms.dll"
)

$root = "$PSScriptRoot/../"

function RunAssembly($testDll)
{
    $idx = $testDll.LastIndexOf('/')
    $folder = $testDll.SubString(0, $idx)

    # Check if folder exists.
    if (Test-Path -Path "$root$folder" -PathType Container) {
        try {
            Push-Location "$root$folder"

            # Check if assembly exists.
            if (Test-Path -Path "$root$testDll" -PathType Leaf) {
                # Delete all PDF files.
                Remove-Item "*.pdf" -ErrorAction Ignore

                # Run the assembly.
                dotnet "$root$testDll"

                if ($IsLinux) {
                    # Give assembly some time.
                    Start-Sleep 2

                    $pdfs = Get-Item "*.pdf"

                    foreach ($pdf in $pdfs) {
                        # Open the PDF in the default viewer (if any).
                        & $pdf
                    }
                }
            }
            else {
                Write-Host "Assembly $assembly does not exist, test cannot run. Run 'dotnet build' to build all assemblies."
            }
        }
        finally {
            Pop-Location
        }
    }
    else {
        Write-Host "Folder $folder does not exist, test cannot run. Run 'dotnet build' to build all assemblies."
    }
}

# Main

foreach ($assembly in $assemblyList) {
    RunAssembly $assembly
}

