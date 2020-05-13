# Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
# Use of this code is subject to the terms of our license.
# A copy of the current license can be obtained at any time by e-mailing
# licensing@syncfusion.com. Any infringement will be prosecuted under
# applicable laws. 


# If you are not familiar with R you can obtain a quick introduction by downloading
# R Succinctly for free from Syncfusion - http://www.syncfusion.com/resources/techportal/ebooks/rsuccinctly
# R Succinctly is also included with this installation and is available here
# Installed Drive :\Program Files (x86)\Syncfusion\Essential Studio\XX.X.X.XX\Infrastructure\EBooks\R_Succintly.pdf OF R Succinctly
# Uncomment below lines to install necessary packages if not installed already
# install.packages("rpart")
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("datasets")

# Load below packages
library(rpart)
library(pmml)
library(gmodels)
library(datasets) # This package is specifically loaded for Iris dataset shipped within it.

# Here we directly load the Iris dataset installed with the "datasets" package.
data(iris)

# Rename column names in iris dataset from datasets package
irisOriginal <- setNames(iris, c("Sepal_Length","Sepal_Width","Petal_Length","Petal_Width","Species"))

# Omit rows with missing values
irisOriginal <- na.omit(irisOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# iris <- read.csv("Iris.csv")

# Randomizing data
iris<- irisOriginal[sample(nrow(irisOriginal)), ]

# Divide dataset for training and test
irisTrain <- iris [1:120, ]
irisTest <- iris [121:150, ]

#Applying TreeModel
irisModel <- rpart( Species ~ ., data = irisTrain)
irisModel 

# Display the predicted results and create cross table to check on accuracy
# Predict "Species" column for test data set
irisTestPrediction<- predict(irisModel ,irisTest, type="class")
# Display predicted values
irisTestPrediction

# Create cross table to check on accuracy.
CrossTable(irisTest$Species, irisTestPrediction, prop.chisq=FALSE,prop.c=FALSE,prop.r=FALSE,dnn = c('actual values','predicted values'))     

# PMML generation
irisPmml<- pmml(irisModel, data = irisTrain)
write (toString (irisPmml), file="Iris.pmml")
saveXML (irisPmml, file="Iris.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original iris data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Apply model to entire dataset and write the results in a csv file
classes = predict(irisModel, newdata = irisOriginal, threshold = 0, type = "class")
probabilities = predict(irisModel, newdata = irisOriginal, threshold = 0, type = "prob")

# Save predicted value in a data frame
writeOutput = function(classes, probabilities, file)
{
 result = NULL
 if(is.null(probabilities))
  {
  result = data.frame(classes)
  names(result) = c("Species")
 } 
  else
 {
  result = data.frame(classes, probabilities)
  names(result) = c("Predicted_Species", "SetosaSpeciesProbability", "VersicolorSpeciesProbability", "VirginicaSpeciesProbability")
 }
 write.csv(result, file, quote=F)
}

# Write the results in a CSV file
writeOutput(classes, probabilities, "ROutput.csv")

