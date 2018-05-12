# Thor AspNetCore

[![release](https://img.shields.io/github/release/ChilliCream/thor-aspnetcore.svg)](https://github.com/ChilliCream/thor-aspnetcore/releases) [![package](https://img.shields.io/nuget/v/Thor.AspNetCore.svg)](https://www.nuget.org/packages/Thor.AspNetCore) [![license](https://img.shields.io/github/license/ChilliCream/thor-aspnetcore.svg)](https://github.com/ChilliCream/thor-aspnetcore/blob/master/LICENSE) [![build](https://img.shields.io/appveyor/ci/rstaib/thor-aspnetcore/master.svg)](https://ci.appveyor.com/project/rstaib/thor-aspnetcore) [![tests](https://img.shields.io/appveyor/tests/rstaib/thor-aspnetcore/master.svg)](https://ci.appveyor.com/project/rstaib/thor-aspnetcore) [![coverage](https://img.shields.io/coveralls/ChilliCream/thor-aspnetcore.svg)](https://coveralls.io/github/ChilliCream/thor-aspnetcore?branch=master)

**The _AspNet_ _Core_ for _Thor_**

The tracing core contains everything to enable _ETW_ tracing in your _.net_ application.

## Getting Started

### Install Package

Here is how the `Thor.AspNetCore` has to be installed via _NuGet_ on a powershell console.

```powershell
Install-Package Thor.AspNetCore
```

### Code Example

Okay, after installing our dependencies we could start writing a bit code.

#### How to scope (group) events together

The following code is not production ready. This code should give only an idea of how to group _ETW_
events into an activity.

```csharp
    ...
}
```

## Documentation

Click [here](https://github.com/ChilliCream/thor-aspnetcore-docs) to get to the documentation home of _Thor AspNetCore_.
