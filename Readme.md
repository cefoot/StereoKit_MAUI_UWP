# [StereoKit Template](https://stereokit.net/)
This Template is based on [MAUI Template](https://github.com/StereoKit/StereoKit.Templates/tree/main/templates/SKTemplate_Multi) from StereoKit.

Included is a small sample game.

# Github Actions
Everytime a Release (&Tag) is created there is an action included which automatically generates *UWP(Arm64)*, *Android* and *Standalone* zip files. To be executed on supporting devices (Quest, HoloLens 2, Windows-PC) 
## Github Token
To give github action access to the releases (to add the binaries) you need to configure the access to the repository. See [Token-Settings](https://github.com/settings/tokens?type=beta) for details.
## Github Secrets
You need a Github Secrets for the UWP (HoloLens) Build to work.
## CERT
Under Github>{Repository}>Settings>Secrets and variables>Actions you need to create "[New repository secret](./settings/secrets/actions/new)" with name `CERT` and value should be the base64 of the UWP (PFX) certificate, used to sign the uwp app.

Microsoft has [documentation](https://learn.microsoft.com/en-gb/windows/msix/package/create-certificate-package-signing) on how to create a certificate for signing.

Use the following powershel command to create base64 from the certificate file.
`[System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes("c:\Cert.pfx"))`

# manual build
## android (Quest)
`dotnet publish -c Release .\Projects\Android\SKTemplate_Multi_Android.csproj -o OUTPUT_Android`
## standalon (Win)
`dotnet publish -c Release .\SKTemplate_Multi.csproj -o OUTPUT_Win`
## UWP (ARM64 for HoloLens 2)
**Hint:** *Certificate.pfx needs to be created before*

`msbuild .\Platforms\StereoKit_UWP\StereoKit_UWP.csproj /p:Platform=ARM64 /p:AppxBundle=Always /p:AppxBundlePlatforms="ARM64" /p:PackageCertificateKeyFile=Certificate.pfx /restore`