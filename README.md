# DOF Commands

This is just a simple application to run DOF commands to the PinOne board through the command line interface.

## Getting started

To use this application, just download the exe from the releases and place it into your C:/DirectOutput directory. Now you can run DOF commands through the command line interface as follows:

```C:\DirectOutput> ./dofcommands.exe 16 255 1500```

The first parameter is the output number to enable, the second command is the value from 0 to 255 (to support pwm operations) and the third command is how long to keep the output enabled before exiting the script.
