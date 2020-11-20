# LoadBalancer challenge

## How do I use it?
### Dependencies

- .NET Core 3+
- Visual Studio 2019 (Recommended)

## Getting Started
### Terminal
Navigate to `./DemoLoadBalance` and execute `dotnet run`. This will start the app in the console and start printing logs.

### IDE
Open the `.sln` file in `Visual Studio 2019`, run the `DemoLoadBalance` project.

## Step 8 
I didn't manage finish the Cluster Capacity Limit feature within the time constraints. If I had more time, I would perhaps use a queue for incoming tasks and keep a track of active tasks in a HashSet. When a task finishes, remove it from the set and pop the next one in from the Q.
