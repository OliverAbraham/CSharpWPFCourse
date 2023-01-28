# WPF Course

This repository contains several demo programs from my WPF course.

## Layout
#### Grids
- Shows how to use grids to create regions in your User Interface.
- Use BackgroundColor to Debug your regions.
- Use LiveUpdate to see your code changes while your app is running.

#### StackPanels
- Shows how to align controls horizontally or vertically using the StackPanel. 
- Shows how to react on size changes and align your controls with a wrap panel.

#### Menus and images
- How to create a simple menu bar with icons instead of text.
- Use MouseLeftButtonDown to react

#### Hover effect
- How to change control properties when the user hovers over them with the mouse. 
- This example changes the item backgrounds on hover
- It makes your app more "living".

#### Layout with 4 sections
- Just a WPF layout with four resizable sections, to be used as boilerplate
- There's no logic behind, just a WPF showcase

#### Rotating controls using Transformations
- How to rotate controls with transformations
- Creating a kind of "round table" with plates

#### Save and restore window positions
- Save the positions and sizes of controls, to restore the users choices on the next run.

#### More
- Refer to https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/controls-by-category?view=netframeworkdesktop-4.8
to learn more about all the layout controls.



## Styling

#### Animations
- How to make controls visible/unvisible smoothly

#### Resource dictionaries
- How to use dictionaries to organize your XAML code better
- This example applies a set of styles to a bunch of buttons

#### Animations
- How to make XAML animate text and graphics
- Animate controls on mouse hovering over
- How to animate rotating gears, as a loading indicator or so

#### Skinning
- How to change the look and feel of your app dynamically at runtime.
- Shows a simple method to switch between a "light" and a "dark" theme
- Precompiled, fixed themes (not dynamically loaded skins)

#### Data grids
- How to add icons to a data grid column
- Icons can bring more clarity to your grid

#### More
- Refer to https://learn.microsoft.com/en-us/dotnet/desktop/wpf/advanced/alignment-margins-and-padding-overview?view=netframeworkdesktop-4.8
to learn more about Alignment, Margins and padding.



## Graphics
#### Images filled from URL
- How to display an image dynamically (instead of a precompiled resource)

#### Canvas and graphics
- How to write graphics onto you app background
- This demonstrates how to create the simple pong game, with just one moving ball

#### Timers
- Use timers to make automatic UI changes

#### Simple graphics
- How to draw primitive graphic elements
- This can be used to build a simple game called "catch the red one"
- uses a timer to redraw the elements every second

#### Graphics moving with mouse
- Shows how to "pick" a shape with the mouse and drag it
- There's a small bug in it: When the user picks a shape, it jumps a bit. Can you fix it?

#### More Graphics
- Improved version of drag and drop
- This is the spoiler of the previous example! Try to solve the task first!


## Controls
#### 01_Simple_controls
- How to use Single value controls for editing (Textboxes, Comboboxes, Checkboxes, Radiobuttons)
- Binding row properties to your controls
- How to implement radiobuttons for a single property

#### 02_Data grids with ObservableCollection
- How to implement a simple data grid for row editing
- insert new rows by cliking on the empty row
- delete rows with the DEL key
- Updating a data grid automatically when the ItemSource changes

#### 03_Data grid_error_handling_
- How to validate datagrid entries

#### 05_Data_grids_Icons_in_columns
- How to use Icons in a data grid column to visualize a state

#### 06_Data_grid_styling_with_images
- How to use Icons in a data grid column to visualize a state

#### 07_Data grids for editing
- Editing grid cells, to save the details window

#### Speech bubble tooltips
- Display a small help text when you hover over a control
- Display introductory texts that explain the usage

#### Speech bubbles_on_click
- Help texts appear at program start and the user has to click them away
- This is meant for explanatory texts, when the user starts your app the first time





## MVVM
- Create a ViewModel that has no references to the UI
- Create unit tests for the ViewModel



## Demo apps
#### Text encryption app
- Fully functional app
- Demonstrates how to do text input in two text controls, and filling them vica versa.
- Demonstrate how to encrypt and decrypt text
- The user can enter plain text in the upper or encrypted text in the lower entryfield

#### Tic Tac Toe
- Fully functional app
- Demonstrates how to do separate the UI from domain logic

#### Editible combobox
- How to implement an editible combobox
- Useful for small models, where a data grid is overkill
- The user can choose an item out of the combobox, add and delete items

#### Elevate with button
- Shows how to aquire elevated rights from the operating system and restart you app with more rights
