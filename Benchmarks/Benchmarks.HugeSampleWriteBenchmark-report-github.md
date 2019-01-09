``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.2 (18C54) [Darwin 18.2.0]
Intel Core i9-8950HK CPU 2.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|    Method | Depth | Childs | Attributes |       Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |------ |------- |----------- |-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| **SystemXml** |     **1** |      **1** |          **0** | **3,277.6 ns** |  **64.55 ns** | **140.32 ns** |      **0.5989** |           **-** |           **-** |              **3.7 KB** |
|   FastXml |     1 |      1 |          0 |   693.7 ns |  13.84 ns |  27.00 ns |      0.1879 |           - |           - |             1.16 KB |
| **SystemXml** |     **1** |      **1** |          **1** | **4,779.8 ns** | **103.80 ns** | **225.65 ns** |      **0.6943** |           **-** |           **-** |              **4.3 KB** |
|   FastXml |     1 |      1 |          1 |   910.1 ns |  14.21 ns |  13.29 ns |      0.2756 |      0.0010 |           - |              1.7 KB |
| **SystemXml** |     **4** |      **1** |          **0** | **4,131.6 ns** |  **81.34 ns** | **142.46 ns** |      **0.6714** |           **-** |           **-** |             **4.14 KB** |
|   FastXml |     4 |      1 |          0 | 1,264.8 ns |  25.03 ns |  48.23 ns |      0.3357 |           - |           - |             2.07 KB |
| **SystemXml** |     **4** |      **1** |          **1** | **6,974.3 ns** | **139.26 ns** | **220.88 ns** |      **0.8621** |      **0.0076** |           **-** |             **5.32 KB** |
|   FastXml |     4 |      1 |          1 | 1,728.5 ns |  39.78 ns |  35.27 ns |      0.5283 |           - |           - |             3.26 KB |
