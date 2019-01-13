``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.523 (1803/April2018Update/Redstone4)
AMD Phenom(tm) II X4 955 Processor, 1 CPU, 4 logical and 4 physical cores
Frequency=3146050 Hz, Resolution=317.8589 ns, Timer=TSC
.NET Core SDK=2.2.102
  [Host]     : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), 64bit RyuJIT


```
|    Method |      Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 14.205 us | 0.2762 us | 0.3288 us |     14.6942 |           - |           - |            15.08 KB |
|   FastXml |  3.047 us | 0.0456 us | 0.0427 us |      1.9493 |           - |           - |                2 KB |
|   NanoXml |  2.535 us | 0.0311 us | 0.0291 us |      1.8196 |           - |           - |             1.87 KB |
