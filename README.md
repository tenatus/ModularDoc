# MarkDoc.Core
Markdown documentation generator for .NET libraries written in C# 8 and lower.

Additional details and a list of supported versions of .NET frameworks will be provided after the [core](https://github.com/hailstorm75/MarkDoc.Core/milestone/1) implementation is complete (see below in roadmap).

Like this project idea and would like to see it grow? Give it a star and follow for the latest updates.

## Produced result

This is my second attempt at creating such a tool. The first one is on [GitLab](https://gitlab.com/hailstorm75/markdoc). You can try it out for your self; however, it only supports .NET Framework libraries with NO DEPENDENCIES.

The result which it produces can be seen in the Wiki of my side project - [Common](https://gitlab.com/hailstorm75/Common/-/wikis/home). All of the Wiki content is generated using the legacy MarkDoc.

The generated structure is inspired by the one outputted by Doxygen. If you do not like it, you can always create your own **Generator** (see below in the technical description) to generate your own custom output.

## Running it

As of writing this ReadMe, there is no user-friendly way of running this project. However, you can try to play around with the assembled test in **Tests/Ut.Generator/BenchmarkTest.cs**.
Run it at your own risk, the code is meant to serve for development purposes.

## Technical description

This project aims to be as modular as possible to support specifics of each **Git** platform and, if so be desired, to generate not only Markdown but other output types such as HTML, LaTeX, or whatever might be required in the future.
With this in mind, the project is separated into the following parts:

| Part | Description |
| ---- | ----------- |
| Members | Retrieve library types structure |
| Documentation | Retrieve library types documentation |
| Elements | Documentation building blocks |
| Generators | Binds the types to their documentation and generates the documentation output | 
| Linkers | Define the documentation file output structure and allow linking types between files |

The parts above are represented as interfaces and thus allow creating decoupled library implementations.

# Roadmap

The project is the early stages of development.

| Stage | Status   | Milestone | Description |
| ----- | -------- | --------- | ----------- |
| Core  | :hammer: | [Issues](https://github.com/hailstorm75/MarkDoc.Core/milestone/1) | Define the core interfaces and create library which implement them. The goal is to ensure that the interfaces provide everything necessary and to successfully generate documentation |
| Reorganize | :mag: |         | Reorganize the project structure such that the interfaces are separate from the libraries which implement them. Prepare the application layer and the plugin layer |
| UI   | :grey_question: |    | Create the application UI |
| Plugins | :grey_question: |  | Create a MarkDoc plugin composed from __modules__ (libraries) |

The biggest issue at hand is coming up with a way to test this project. All testing is done manually and has proven to miss most of the issues.
