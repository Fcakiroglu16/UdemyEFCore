1.) dotnet ef dbcontext optimize --output-dir MyCompiledModel --namespace MyCompiledModels
2.)  optionsBuilder.UseModel(MyCompiledModels.AppDbContextModel.Instance);