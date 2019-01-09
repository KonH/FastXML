``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method | Depth | Childs | Attributes |       Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |------ |------- |----------- |-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| **SystemXml** |     **1** |      **1** |          **0** | **3,278.2 ns** |  **65.50 ns** | **121.40 ns** |      **0.5989** |           **-** |           **-** |              **3.7 KB** |
|   FastXml |     1 |      1 |          0 |   687.7 ns |  13.61 ns |  26.22 ns |      0.1879 |           - |           - |             1.16 KB |
| **SystemXml** |     **1** |      **1** |          **1** | **4,709.5 ns** |  **93.29 ns** | **163.38 ns** |      **0.6943** |      **0.0076** |           **-** |              **4.3 KB** |
|   FastXml |     1 |      1 |          1 |   921.3 ns |  18.35 ns |  24.50 ns |      0.2756 |      0.0010 |           - |              1.7 KB |
| **SystemXml** |     **4** |      **1** |          **0** | **4,199.4 ns** |  **83.18 ns** | **158.26 ns** |      **0.6714** |           **-** |           **-** |             **4.14 KB** |
|   FastXml |     4 |      1 |          0 | 1,259.4 ns |  23.77 ns |  45.22 ns |      0.3357 |           - |           - |             2.07 KB |
| **SystemXml** |     **4** |      **1** |          **1** | **7,311.3 ns** | **145.32 ns** | **279.99 ns** |      **0.8621** |      **0.0076** |           **-** |             **5.32 KB** |
|   FastXml |     4 |      1 |          1 | 1,744.5 ns |  33.11 ns |  32.52 ns |      0.5283 |           - |           - |             3.26 KB |
