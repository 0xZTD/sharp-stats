cmd ?= ""
run:
	dotnet run --project TekkenTracker.CLI $(cmd)

watch:
	dotnet watch --project TekkenTracker.CLI