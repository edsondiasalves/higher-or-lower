[![.NET](https://github.com/edsondiasalves/higher-or-lower/actions/workflows/dotnet.yml/badge.svg)](https://github.com/edsondiasalves/higher-or-lower/actions/workflows/dotnet.yml) [![Coverage Status](https://coveralls.io/repos/github/edsondiasalves/higher-or-lower/badge.svg?branch=main)](https://coveralls.io/github/edsondiasalves/higher-or-lower?branch=main)

# higher-or-lower

## How To Play

### Run it on your machine
####  
- Clone the solution: `git clone https://github.com/edsondiasalves/higher-or-lower.git`
- Go to the root `cd higher-or-lower`
- Run the app: `dotnet run --project src/service.csproj`
- [Click here](https://localhost:5001/index.html)


### Run it with docker
####  
- Clone the solution: `git clone https://github.com/edsondiasalves/higher-or-lower.git`
- Go to the root `cd higher-or-lower`
- Build the docker image: `docker build -t game .`
- Run the docker image: `docker run -it --rm -p 5001:80 --name gamecontainer game`
- [Click here](http://localhost:5001/index.html)