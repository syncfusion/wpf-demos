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
# install.packages("MASS")

# Load below packages
library(rpart)
library(pmml)
library(gmodels)
library(MASS) # This package is specifically loaded for Fgl dataset shipped within it.

# Here we directly load the Fgl dataset installed with the "MASS" package.
data(fgl)

# rename column names in fgl dataset from MASS package
glassOriginal <- setNames(fgl, c("Refractive_Index", "Sodium", "Magnesium", "Aluminium", "Silicon", "Potassium", "Calcium", "Barium", "Iron", "Type"))

# Omit rows with missing values
glassOriginal <- na.omit(glassOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# glass<- read.csv("Glass.csv")

# Randomizing data
glass<- glassOriginal[sample(nrow(glassOriginal)),]

# Divide dataset for training and test
glassTrain <- glass[1:171, ]
glassTest <- glass[172:214, ]

# Applying TreeModel
glassModel <- rpart(Type ~ ., data = glassTrain)
glassModel

# Display the predicted results and create cross table to check on accuracy
# Predict "type" column for test data set
glassTestPrediction<- predict(glassModel ,glassTest, type="class")
# Display predicted values
glassTestPrediction

# Create cross table to check on accuracy.
CrossTable(glassTest$Type, glassTestPrediction, prop.chisq=FALSE,prop.c=FALSE,prop.r=FALSE,dnn = c('actual values','predicted values'))     

# PMML generation
glassPmml<- pmml(glassModel, data = glassTrain)
write (toString (glassPmml), file="Glass.pmml")
saveXML (glassPmml, file="Glass.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original fgl data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Apply model to entire dataset and write the results in a csv file
classes = predict(glassModel, newdata = glassOriginal, threshold = 0, type = "class")
probabilities = predict(glassModel, newdata = glassOriginal, threshold = 0, type = "prob")

# Save predicted value in a data frame
writeOutput = function(classes, probabilities, file)
{
 result = NULL
 if(is.null(probabilities))
  {
  result = data.frame(classes)
  names(result) = c("Type")
 } 
  else
 {
  result = data.frame(classes, probabilities)
  names(result) = c("Predicted_Type", "WindowFloatGlassTypeProbability", "WindowNon-floatGlassTypeProbability","VehicleWindowGlassTypeProbability" ,"ContainersTypeProbability", "TablewareTypeProbability", "VehicleHeadlampsTypeProbability")
 }
 write.csv(result, file, quote=F)
}

# Write the results in a CSV file
writeOutput(classes, probabilities, "ROutput.csv")

