// <auto-generated/>
// Emik.SourceGenerators.Tattoo, v2.0.7
#pragma warning disable
global using global::System;
global using global::System.Buffers;
global using global::System.Buffers.Binary;
global using global::System.Buffers.Text;
global using global::System.CodeDom;
global using global::System.CodeDom.Compiler;
global using global::System.Collections;
global using global::System.Collections.Concurrent;
global using global::System.Collections.Frozen;
global using global::System.Collections.Generic;
global using global::System.Collections.Immutable;
global using global::System.Collections.ObjectModel;
global using global::System.Collections.Specialized;
global using global::System.ComponentModel;
global using global::System.ComponentModel.DataAnnotations;
global using global::System.ComponentModel.DataAnnotations.Schema;
global using global::System.ComponentModel.Design;
global using global::System.ComponentModel.Design.Serialization;
global using global::System.Configuration;
global using global::System.Configuration.Assemblies;
global using global::System.Configuration.Internal;
global using global::System.Configuration.Provider;
global using global::System.Data;
global using global::System.Data.Common;
global using global::System.Data.Odbc;
global using global::System.Data.OleDb;
global using global::System.Data.Sql;
global using global::System.Data.SqlClient;
global using global::System.Data.SqlTypes;
global using global::System.Diagnostics;
global using global::System.Diagnostics.CodeAnalysis;
global using global::System.Diagnostics.Contracts;
global using global::System.Diagnostics.Eventing;
global using global::System.Diagnostics.Eventing.Reader;
global using global::System.Diagnostics.Metrics;
global using global::System.Diagnostics.PerformanceData;
global using global::System.Diagnostics.SymbolStore;
global using global::System.Diagnostics.Tracing;
global using global::System.Drawing;
global using global::System.Drawing.Configuration;
global using global::System.Drawing.Design;
global using global::System.Drawing.Drawing2D;
global using global::System.Drawing.Imaging;
global using global::System.Drawing.Printing;
global using global::System.Drawing.Text;
global using global::System.Dynamic;
global using global::System.Formats;
global using global::System.Formats.Asn1;
global using global::System.Formats.Tar;
global using global::System.Globalization;
global using global::System.IO;
global using global::System.IO.Compression;
global using global::System.IO.Enumeration;
global using global::System.IO.IsolatedStorage;
global using global::System.IO.MemoryMappedFiles;
global using global::System.IO.Packaging;
global using global::System.IO.Pipes;
global using global::System.IO.Ports;
global using global::System.Linq;
global using global::System.Linq.Expressions;
global using global::System.Media;
global using global::System.Net;
global using global::System.Net.Cache;
global using global::System.Net.Http;
global using global::System.Net.Http.Headers;
global using global::System.Net.Http.Json;
global using global::System.Net.Http.Metrics;
global using global::System.Net.Mail;
global using global::System.Net.Mime;
global using global::System.Net.NetworkInformation;
global using global::System.Net.PeerToPeer;
global using global::System.Net.PeerToPeer.Collaboration;
global using global::System.Net.Quic;
global using global::System.Net.Security;
global using global::System.Net.Sockets;
global using global::System.Net.WebSockets;
global using global::System.Numerics;
global using global::System.Reflection;
global using global::System.Reflection.Emit;
global using global::System.Reflection.Metadata;
global using global::System.Reflection.Metadata.Ecma335;
global using global::System.Reflection.PortableExecutable;
global using global::System.Resources;
global using global::System.Runtime;
global using global::System.Runtime.CompilerServices;
global using global::System.Runtime.ConstrainedExecution;
global using global::System.Runtime.ExceptionServices;
global using global::System.Runtime.InteropServices;
global using global::System.Runtime.InteropServices.ComTypes;
global using global::System.Runtime.InteropServices.JavaScript;
global using global::System.Runtime.InteropServices.Marshalling;
global using global::System.Runtime.InteropServices.ObjectiveC;
global using global::System.Runtime.Intrinsics;
global using global::System.Runtime.Intrinsics.Arm;
global using global::System.Runtime.Intrinsics.Wasm;
global using global::System.Runtime.Intrinsics.X86;
global using global::System.Runtime.Loader;
global using global::System.Runtime.Remoting;
global using global::System.Runtime.Serialization;
global using global::System.Runtime.Serialization.DataContracts;
global using global::System.Runtime.Serialization.Formatters;
global using global::System.Runtime.Serialization.Formatters.Binary;
global using global::System.Runtime.Serialization.Json;
global using global::System.Runtime.Versioning;
global using global::System.Security;
global using global::System.Security.AccessControl;
global using global::System.Security.Authentication;
global using global::System.Security.Authentication.ExtendedProtection;
global using global::System.Security.Claims;
global using global::System.Security.Cryptography;
global using global::System.Security.Cryptography.Pkcs;
global using global::System.Security.Cryptography.X509Certificates;
global using global::System.Security.Cryptography.Xml;
global using global::System.Security.Permissions;
global using global::System.Security.Policy;
global using global::System.Security.Principal;
global using global::System.ServiceModel;
global using global::System.ServiceModel.Syndication;
global using global::System.ServiceProcess;
global using global::System.Text;
global using global::System.Text.Encodings;
global using global::System.Text.Encodings.Web;
global using global::System.Text.Json;
global using global::System.Text.Json.Nodes;
global using global::System.Text.Json.Serialization;
global using global::System.Text.Json.Serialization.Metadata;
global using global::System.Text.RegularExpressions;
global using global::System.Text.Unicode;
global using global::System.Threading;
global using global::System.Threading.Channels;
global using global::System.Threading.Tasks;
global using global::System.Threading.Tasks.Dataflow;
global using global::System.Threading.Tasks.Sources;
global using global::System.Timers;
global using global::System.Transactions;
global using global::System.Web;
global using global::System.Windows;
global using global::System.Windows.Input;
global using global::System.Windows.Markup;
global using global::System.Xml;
global using global::System.Xml.Linq;
global using global::System.Xml.Resolvers;
global using global::System.Xml.Schema;
global using global::System.Xml.Serialization;
global using global::System.Xml.XPath;
global using global::System.Xml.Xsl;
global using global::CommunityToolkit;
global using global::CommunityToolkit.Common;
global using global::CommunityToolkit.Common.Collections;
global using global::CommunityToolkit.Common.Deferred;
global using global::CommunityToolkit.Common.Extensions;
global using global::CommunityToolkit.Common.Helpers;
global using global::CommunityToolkit.Diagnostics;
global using global::CommunityToolkit.Helpers;
global using global::CommunityToolkit.HighPerformance;
global using global::CommunityToolkit.HighPerformance.Buffers;
global using global::CommunityToolkit.HighPerformance.Buffers.Internals;
global using global::CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces;
global using global::CommunityToolkit.HighPerformance.Buffers.Views;
global using global::CommunityToolkit.HighPerformance.Enumerables;
global using global::CommunityToolkit.HighPerformance.Helpers;
global using global::CommunityToolkit.HighPerformance.Helpers.Internals;
global using global::CommunityToolkit.HighPerformance.Memory;
global using global::CommunityToolkit.HighPerformance.Memory.Internals;
global using global::CommunityToolkit.HighPerformance.Memory.Views;
global using global::CommunityToolkit.HighPerformance.Streams;
global using global::DotNetProjectFile;
global using global::DotNetProjectFile.Analyzers;
global using global::DotNetProjectFile.Analyzers.Helpers;
global using global::DotNetProjectFile.Analyzers.MsBuild;
global using global::DotNetProjectFile.Analyzers.Resx;
global using global::DotNetProjectFile.Caching;
global using global::DotNetProjectFile.CodeAnalysis;
global using global::DotNetProjectFile.Diagnostics;
global using global::DotNetProjectFile.IO;
global using global::DotNetProjectFile.MsBuild;
global using global::DotNetProjectFile.MsBuild.Conversion;
global using global::DotNetProjectFile.NuGet;
global using global::DotNetProjectFile.Resx;
global using global::Emik;
global using global::Emik.Morsels;
global using global::Fody;
global using global::ILMerge;
global using global::InlineIL;
global using global::InlineMethod;
global using global::JetBrains;
global using global::JetBrains.Annotations;
global using global::Lazy;
global using global::LocalsInit;
global using global::Microsoft;
global using global::Microsoft.CSharp;
global using global::Microsoft.CSharp.RuntimeBinder;
global using global::Microsoft.CodeAnalysis;
global using global::Microsoft.CodeAnalysis.Diagnostics;
global using global::Microsoft.CodeAnalysis.Text;
global using global::Microsoft.SqlServer;
global using global::Microsoft.SqlServer.Server;
global using global::Microsoft.VisualBasic;
global using global::Microsoft.VisualBasic.CompilerServices;
global using global::Microsoft.VisualBasic.FileIO;
global using global::Microsoft.Win32;
global using global::Microsoft.Win32.SafeHandles;
global using global::NullGuard;
global using global::NullGuard.CodeAnalysis;
global using global::Scifa;
global using global::Scifa.CheckedExceptions;
global using global::Scifa.CheckedExceptions.Attributes;
global using global::Serilog;
global using global::Serilog.Capturing;
global using global::Serilog.Configuration;
global using global::Serilog.Context;
global using global::Serilog.Core;
global using global::Serilog.Core.Enrichers;
global using global::Serilog.Core.Filters;
global using global::Serilog.Core.Pipeline;
global using global::Serilog.Core.Sinks;
global using global::Serilog.Data;
global using global::Serilog.Debugging;
global using global::Serilog.Events;
global using global::Serilog.Filters;
global using global::Serilog.Formatting;
global using global::Serilog.Formatting.Compact;
global using global::Serilog.Formatting.Display;
global using global::Serilog.Formatting.Json;
global using global::Serilog.Parsing;
global using global::Serilog.Policies;
global using global::Serilog.Rendering;
global using global::Serilog.Settings;
global using global::Serilog.Settings.KeyValuePairs;
global using global::Serilog.Sinks;
global using global::Serilog.Sinks.File;
global using global::Serilog.Sinks.SystemConsole;
global using global::Serilog.Sinks.SystemConsole.Formatting;
global using global::Serilog.Sinks.SystemConsole.Output;
global using global::Serilog.Sinks.SystemConsole.Platform;
global using global::Serilog.Sinks.SystemConsole.Rendering;
global using global::Serilog.Sinks.SystemConsole.Themes;
global using global::Substitute;
global using global::UnitGenerator;
global using global::Virtuosity;

// Polyfills of namespaces in case dependencies are conditional.
namespace System { }

namespace System.Buffers { }

namespace System.Buffers.Binary { }

namespace System.Buffers.Text { }

namespace System.CodeDom { }

namespace System.CodeDom.Compiler { }

namespace System.Collections { }

namespace System.Collections.Concurrent { }

namespace System.Collections.Frozen { }

namespace System.Collections.Generic { }

namespace System.Collections.Immutable { }

namespace System.Collections.ObjectModel { }

namespace System.Collections.Specialized { }

namespace System.ComponentModel { }

namespace System.ComponentModel.DataAnnotations { }

namespace System.ComponentModel.DataAnnotations.Schema { }

namespace System.ComponentModel.Design { }

namespace System.ComponentModel.Design.Serialization { }

namespace System.Configuration { }

namespace System.Configuration.Assemblies { }

namespace System.Configuration.Internal { }

namespace System.Configuration.Provider { }

namespace System.Data { }

namespace System.Data.Common { }

namespace System.Data.Odbc { }

namespace System.Data.OleDb { }

namespace System.Data.Sql { }

namespace System.Data.SqlClient { }

namespace System.Data.SqlTypes { }

namespace System.Diagnostics { }

namespace System.Diagnostics.CodeAnalysis { }

namespace System.Diagnostics.Contracts { }

namespace System.Diagnostics.Eventing { }

namespace System.Diagnostics.Eventing.Reader { }

namespace System.Diagnostics.Metrics { }

namespace System.Diagnostics.PerformanceData { }

namespace System.Diagnostics.SymbolStore { }

namespace System.Diagnostics.Tracing { }

namespace System.Drawing { }

namespace System.Drawing.Configuration { }

namespace System.Drawing.Design { }

namespace System.Drawing.Drawing2D { }

namespace System.Drawing.Imaging { }

namespace System.Drawing.Printing { }

namespace System.Drawing.Text { }

namespace System.Dynamic { }

namespace System.Formats { }

namespace System.Formats.Asn1 { }

namespace System.Formats.Tar { }

namespace System.Globalization { }

namespace System.IO { }

namespace System.IO.Compression { }

namespace System.IO.Enumeration { }

namespace System.IO.IsolatedStorage { }

namespace System.IO.MemoryMappedFiles { }

namespace System.IO.Packaging { }

namespace System.IO.Pipes { }

namespace System.IO.Ports { }

namespace System.Linq { }

namespace System.Linq.Expressions { }

namespace System.Media { }

namespace System.Net { }

namespace System.Net.Cache { }

namespace System.Net.Http { }

namespace System.Net.Http.Headers { }

namespace System.Net.Http.Json { }

namespace System.Net.Http.Metrics { }

namespace System.Net.Mail { }

namespace System.Net.Mime { }

namespace System.Net.NetworkInformation { }

namespace System.Net.PeerToPeer { }

namespace System.Net.PeerToPeer.Collaboration { }

namespace System.Net.Quic { }

namespace System.Net.Security { }

namespace System.Net.Sockets { }

namespace System.Net.WebSockets { }

namespace System.Numerics { }

namespace System.Reflection { }

namespace System.Reflection.Emit { }

namespace System.Reflection.Metadata { }

namespace System.Reflection.Metadata.Ecma335 { }

namespace System.Reflection.PortableExecutable { }

namespace System.Resources { }

namespace System.Runtime { }

namespace System.Runtime.CompilerServices { }

namespace System.Runtime.ConstrainedExecution { }

namespace System.Runtime.ExceptionServices { }

namespace System.Runtime.InteropServices { }

namespace System.Runtime.InteropServices.ComTypes { }

namespace System.Runtime.InteropServices.JavaScript { }

namespace System.Runtime.InteropServices.Marshalling { }

namespace System.Runtime.InteropServices.ObjectiveC { }

namespace System.Runtime.Intrinsics { }

namespace System.Runtime.Intrinsics.Arm { }

namespace System.Runtime.Intrinsics.Wasm { }

namespace System.Runtime.Intrinsics.X86 { }

namespace System.Runtime.Loader { }

namespace System.Runtime.Remoting { }

namespace System.Runtime.Serialization { }

namespace System.Runtime.Serialization.DataContracts { }

namespace System.Runtime.Serialization.Formatters { }

namespace System.Runtime.Serialization.Formatters.Binary { }

namespace System.Runtime.Serialization.Json { }

namespace System.Runtime.Versioning { }

namespace System.Security { }

namespace System.Security.AccessControl { }

namespace System.Security.Authentication { }

namespace System.Security.Authentication.ExtendedProtection { }

namespace System.Security.Claims { }

namespace System.Security.Cryptography { }

namespace System.Security.Cryptography.Pkcs { }

namespace System.Security.Cryptography.X509Certificates { }

namespace System.Security.Cryptography.Xml { }

namespace System.Security.Permissions { }

namespace System.Security.Policy { }

namespace System.Security.Principal { }

namespace System.ServiceModel { }

namespace System.ServiceModel.Syndication { }

namespace System.ServiceProcess { }

namespace System.Text { }

namespace System.Text.Encodings { }

namespace System.Text.Encodings.Web { }

namespace System.Text.Json { }

namespace System.Text.Json.Nodes { }

namespace System.Text.Json.Serialization { }

namespace System.Text.Json.Serialization.Metadata { }

namespace System.Text.RegularExpressions { }

namespace System.Text.Unicode { }

namespace System.Threading { }

namespace System.Threading.Channels { }

namespace System.Threading.Tasks { }

namespace System.Threading.Tasks.Dataflow { }

namespace System.Threading.Tasks.Sources { }

namespace System.Timers { }

namespace System.Transactions { }

namespace System.Web { }

namespace System.Windows { }

namespace System.Windows.Input { }

namespace System.Windows.Markup { }

namespace System.Xml { }

namespace System.Xml.Linq { }

namespace System.Xml.Resolvers { }

namespace System.Xml.Schema { }

namespace System.Xml.Serialization { }

namespace System.Xml.XPath { }

namespace System.Xml.Xsl { }

namespace CommunityToolkit { }

namespace CommunityToolkit.Common { }

namespace CommunityToolkit.Common.Collections { }

namespace CommunityToolkit.Common.Deferred { }

namespace CommunityToolkit.Common.Extensions { }

namespace CommunityToolkit.Common.Helpers { }

namespace CommunityToolkit.Diagnostics { }

namespace CommunityToolkit.Helpers { }

namespace CommunityToolkit.HighPerformance { }

namespace CommunityToolkit.HighPerformance.Buffers { }

namespace CommunityToolkit.HighPerformance.Buffers.Internals { }

namespace CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces { }

namespace CommunityToolkit.HighPerformance.Buffers.Views { }

namespace CommunityToolkit.HighPerformance.Enumerables { }

namespace CommunityToolkit.HighPerformance.Helpers { }

namespace CommunityToolkit.HighPerformance.Helpers.Internals { }

namespace CommunityToolkit.HighPerformance.Memory { }

namespace CommunityToolkit.HighPerformance.Memory.Internals { }

namespace CommunityToolkit.HighPerformance.Memory.Views { }

namespace CommunityToolkit.HighPerformance.Streams { }

namespace DotNetProjectFile { }

namespace DotNetProjectFile.Analyzers { }

namespace DotNetProjectFile.Analyzers.Helpers { }

namespace DotNetProjectFile.Analyzers.MsBuild { }

namespace DotNetProjectFile.Analyzers.Resx { }

namespace DotNetProjectFile.Caching { }

namespace DotNetProjectFile.CodeAnalysis { }

namespace DotNetProjectFile.Diagnostics { }

namespace DotNetProjectFile.IO { }

namespace DotNetProjectFile.MsBuild { }

namespace DotNetProjectFile.MsBuild.Conversion { }

namespace DotNetProjectFile.NuGet { }

namespace DotNetProjectFile.Resx { }

namespace Emik { }

namespace Emik.Morsels { }

namespace Fody { }

namespace ILMerge { }

namespace InlineIL { }

namespace InlineMethod { }

namespace JetBrains { }

namespace JetBrains.Annotations { }

namespace Lazy { }

namespace LocalsInit { }

namespace Microsoft { }

namespace Microsoft.CSharp { }

namespace Microsoft.CSharp.RuntimeBinder { }

namespace Microsoft.CodeAnalysis { }

namespace Microsoft.CodeAnalysis.Diagnostics { }

namespace Microsoft.CodeAnalysis.Text { }

namespace Microsoft.SqlServer { }

namespace Microsoft.SqlServer.Server { }

namespace Microsoft.VisualBasic { }

namespace Microsoft.VisualBasic.CompilerServices { }

namespace Microsoft.VisualBasic.FileIO { }

namespace Microsoft.Win32 { }

namespace Microsoft.Win32.SafeHandles { }

namespace NullGuard { }

namespace NullGuard.CodeAnalysis { }

namespace Scifa { }

namespace Scifa.CheckedExceptions { }

namespace Scifa.CheckedExceptions.Attributes { }

namespace Serilog { }

namespace Serilog.Capturing { }

namespace Serilog.Configuration { }

namespace Serilog.Context { }

namespace Serilog.Core { }

namespace Serilog.Core.Enrichers { }

namespace Serilog.Core.Filters { }

namespace Serilog.Core.Pipeline { }

namespace Serilog.Core.Sinks { }

namespace Serilog.Data { }

namespace Serilog.Debugging { }

namespace Serilog.Events { }

namespace Serilog.Filters { }

namespace Serilog.Formatting { }

namespace Serilog.Formatting.Compact { }

namespace Serilog.Formatting.Display { }

namespace Serilog.Formatting.Json { }

namespace Serilog.Parsing { }

namespace Serilog.Policies { }

namespace Serilog.Rendering { }

namespace Serilog.Settings { }

namespace Serilog.Settings.KeyValuePairs { }

namespace Serilog.Sinks { }

namespace Serilog.Sinks.File { }

namespace Serilog.Sinks.SystemConsole { }

namespace Serilog.Sinks.SystemConsole.Formatting { }

namespace Serilog.Sinks.SystemConsole.Output { }

namespace Serilog.Sinks.SystemConsole.Platform { }

namespace Serilog.Sinks.SystemConsole.Rendering { }

namespace Serilog.Sinks.SystemConsole.Themes { }

namespace Substitute { }

namespace UnitGenerator { }

namespace Virtuosity { }
