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
# install.packages("e1071")
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("rattle")

# Load below packages
library(e1071)
library(pmml) 
library(gmodels)
library(rattle.data) # This package is specifically loaded for wine dataset shipped within it.

# Here we directly load the wine dataset installed with the "rattle" package.
data(wine)

# rename column names in wine dataset from rattle.data package
wineOriginal <- setNames(wine, c("Type", "Alcohol", "Malic_Acid","Ash","Alcalinity","Magnesium","Phenols","Flavanoids","Non_Flavanoids","Proanthocyanins","Color_Intensity","Hue","Dilution","Proline"))

# Omit rows with missing values
wineOriginal <- na.omit(wineOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# wine<- read.csv("Wine.csv")

# Considering integer variable as factor
wineOriginal$Type <- factor(wineOriginal$Type, ordered = FALSE)

#Randomizing data
wine <-wineOriginal[sample(nrow(wineOriginal)),]

# Divide dataset for training and test
trainData <- wine[1:142, ]
testData  <- wine[143:178, ]

# Set predicted field in formula
formula = formula(Type ~ .)

# Create model for training set using naiveBayes 
wineTrainingModel = naiveBayes(formula, trainData, threshold = 0)

# Display the predicted results and create cross table to check on accuracy
# Predict "Adjusted" column for test data set
wineTestPrediction <- predict(wineTrainingModel, testData)
# Display predicted values
wineTestPrediction

# Create cross table to check on accuracy.
CrossTable(wineTestPrediction, testData$Type,
           prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,
           dnn = c('predicted', 'actual'))


# PMML generation 
saveXML(pmml(wineTrainingModel, predictedField = "Type"), "Wine.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original wine data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Naive Bayes model to entire dataset and save the results in a CSV file
classes = predict(wineTrainingModel, newdata = wineOriginal, threshold = 0, type = "class")
probabilities = predict(wineTrainingModel, newdata = wineOriginal, threshold = 0, type = "raw")

# Save predicted value in a data frame
writeOutput = function(classes, probabilities, file){
	result = NULL
	if(is.null(probabilities)){
		result = data.frame(classes)
		names(result) = c("Type")
	} else
	{
		result = data.frame(classes, probabilities)
		names(result) = c("Type", "FirstClassWineProbability", "SecondClassWineProbability","ThirdClassWineProbability")
	}
	write.csv(result, file, quote=F)
}

# Write the results in a CSV file
writeOutput(classes, probabilities, "ROutput.csv")

