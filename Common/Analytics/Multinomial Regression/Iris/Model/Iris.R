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
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("datasets")
# install.packages("caret")
# install.packages("e1071")
# install.packages("nnet")

# Load below packages
library(pmml)
library(gmodels)
library(datasets) # This package is specifically loaded for iris dataset shipped within it.
library(caret)
library(nnet)
library(e1071)

# Here we directly load the audit dataset installed with the "datasets" package.
data(iris)

# Replacing column names in iris dataset from datasets package
irisOriginal <- setNames(iris, c("Sepal_Length","Sepal_Width","Petal_Length","Petal_Width","Species"))

# Omit rows with missing values
iris = na.omit(iris)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# iris= read.csv("Iris.csv")

# Randomizing data
iris<- irisOriginal[sample(nrow(irisOriginal)),]

# Divide dataset for training and test
trainData<-iris[1:120,]
testData<-iris[121:150,]

# Applying Multinomial Regression Model to predict Species
irisFormula = formula(Species ~.)
iris_Multinom = multinom(irisFormula, trainData, trace=F)
summary(iris_Multinom)

# Display the predicted results and create cross table to check on accuracy
# Predict "Species" column probability for test data set
irisTestProbabilities = predict(iris_Multinom ,type = "probs",testData)
# Display predicted probabilities
irisTestProbabilities

# Predict Species values for test dataset
irisTestPrediction= predict(iris_Multinom ,type = "class",testData)
# Display predicted value
irisTestPrediction

# Create cross table to check on accuracy.
CrossTable(irisTestPrediction,testData$Species,  prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,dnn = c('predicted', 'actual'))

# PMML generation
pmmlFile<-pmml(iris_Multinom,data=trainData)
write(toString(pmmlFile),file="Iris.pmml")
saveXML(pmmlFile,file="Iris.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original iris data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Multinomial Regression model to entire dataset and save the results in a CSV file
irisEntireProbabilities = predict(iris_Multinom, type = "probs",irisOriginal)
irisEntirePrediction = predict(iris_Multinom, type = "class",irisOriginal)

# Save predicted value in a data frame
result = data.frame(irisEntirePrediction, irisEntireProbabilities)
names(result) = c("Predicted_Species", "SetosaSpeciesProbability", "VersicolorSpeciesProbability", "VirginicaSpeciesProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)


