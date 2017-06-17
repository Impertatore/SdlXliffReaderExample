# SDLXLIFF Reader Example


# About

A simple standalone project for reading an SDLXLIFF file using the SDL FilterTypeSupport framework API.

The code demonstrates the following
- Create a simple Standalone project that implements the **FilterTypeSupport** API from SDL
- Open an SDLXLIFF file and iterate over the segments
- How to recover the content from each segment (source & target) using the IMarkupDataVisitor
- Includes a tokenizer that recognizes the standard patterns (Dates, Times, Numbers, Acronymns, Variables, Measurements, Alphanumeric)

