# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

MSDMarkwort.Kicad.Parser is a comprehensive .NET 8.0 parser library for KiCad EDA files, implementing a robust attribute-driven architecture for parsing various KiCad file formats.

## Architecture Overview

### Core Components
- **S-Expression Parser** (`SExpressionParser.cs`): Low-level parser handling KiCad's S-expression format
- **Base Parser Framework** (`KicadBaseParser<TModel, TRootModel>`): Generic base parser providing reflection-based model population
- **Attribute System**: Custom attributes for mapping S-expressions to C# properties
- **Type Cache**: Performance-optimized reflection cache for property mapping

### Supported File Formats

1. **PCB Files** (`*.kicad_pcb`, `*.kicad_mod`)
   - Full PCB layout parsing
   - Footprint libraries and tables
   - Minimum version: 20200829 (KiCad 6.0)

2. **Schematic Files** (`*.kicad_sch`, `*.kicad_sym`)
   - Complete schematic parsing
   - Symbol libraries and tables
   - Hierarchical sheet support

3. **Project Files** (`*.kicad_pro`)
   - JSON-based format using System.Text.Json
   - Async parsing support

## Key Design Patterns

### Attribute-Driven Mapping
- `KicadParserSymbol`: Maps S-expression symbols to properties
- `KicadParameter`: Maps positional parameters
- `KicadParserList`: Handles collections with different add strategies
- `KicadParserComplexSymbol`: Nested object mapping

### Parser Pipeline
1. Stream → S-Expression tree (tokenization)
2. S-Expression → Model objects (reflection-based mapping)
3. Validation and warning collection
4. Result wrapping with success/error status

## Project Structure

```
src/
├── MSDMarkwort.Kicad.Parser.Base/       # Core parsing infrastructure
│   ├── Attributes/                      # Custom attribute definitions
│   ├── Parser/
│   │   ├── SExpression/                 # S-expression tokenizer
│   │   ├── Reflection/                  # Type cache and property setters
│   │   └── Pcb/                        # Base parser implementation
├── MSDMarkwort.Kicad.Parser.Model/      # Common model classes
├── MSDMarkwort.Kicad.Parser.EESchema/   # Schematic parser
├── MSDMarkwort.Kicad.Parser.PcbNew/     # PCB parser
├── MSDMarkwort.Kicad.Parser.Project/    # Project file parser
└── Tests/                               # Comprehensive test suite
```

## Current Status

✅ **String to Enum Conversion Completed** - Successfully replaced string properties with type-safe enums across all parser types with automatic conversion infrastructure.

✅ **All Tests Passing** - 551 total tests (66 Project + 190 EESchema + 295 PcbNew) completed successfully.

## Code Coverage Results

| Test Suite | Line Coverage | Branch Coverage | Lines Covered/Total | Branches Covered/Total |
|------------|---------------|-----------------|---------------------|------------------------|
| **EESchema.Tests** | 75.7% | 67.3% | 684/904 | 113/168 |
| **PcbNew.Tests** | 84.3% | 77.2% | 991/1176 | 125/162 |
| **Project.Tests** | 28.9% | 0% | 382/1319 | 0/168 |
| **Overall** | **68.4%** | **58.8%** | **2057/3399** | **238/498** |

## Important Instruction Reminders
Do what has been asked; nothing more, nothing less.
NEVER create files unless they're absolutely necessary for achieving your goal.
ALWAYS prefer editing an existing file to creating a new one.
NEVER proactively create documentation files (*.md) or README files. Only create documentation files if explicitly requested by the User.

## Todo List

### New Test Cases to Increase Code Coverage

**Priority 1: Project.Tests (28.9% coverage - Critical)**
- [ ] Test KicadProjectParser error handling and malformed JSON scenarios
- [ ] Test KicadProjectWriter edge cases and write failures
- [ ] Add validation tests for project structure and required fields
- [ ] Test async parsing with various stream conditions

**Priority 2: Exception Handling (0% coverage in many areas)**
- [ ] Test ParserException creation and LineNumber property access
- [ ] Test SExpression parsing error scenarios and malformed syntax
- [ ] Test EnumPropertySetter with invalid enum values and edge cases
- [ ] Test TypeCache with malformed assemblies and missing types

**Priority 3: ToString Methods (Many uncovered)**
- [ ] Test ToString() implementations in SExpr models (SExprSymbol, SExprString, SExprList)
- [ ] Test ToString() implementations in model classes (Position, Size, Effects, etc.)
- [ ] Test ToString() implementations in PCB models (Footprint, Net, Property, etc.)

**Priority 4: Branch Coverage Improvements**
- [ ] Test conditional logic in GeneralPropertySetter.IsList() method
- [ ] Test edge cases in KicadBaseParser complex symbol handling
- [ ] Test boundary conditions in SExpressionParser tokenization
- [ ] Test list processing edge cases with empty and malformed collections

**Priority 5: Property Setter Edge Cases**
- [ ] Test EnumPropertySetter with null/empty values and normalization edge cases
- [ ] Test all property setters with boundary values and invalid inputs
- [ ] Test reflection-based property mapping with missing or incompatible properties

- [x] Ignore `TestResults` folder in `.gitignore`
- [x] Run tests. If there are any failed tests list them as own todo per failed test. Write code coverage result to this file. Do not remove this line when clean up.
- [ ] Cleanup & Update this file. Remove all unnecessary stuff and completed todos except the ones that are marked as do not remove. Add Todo list with all not completed task and add as last Task this line. Mark this line not as completed.