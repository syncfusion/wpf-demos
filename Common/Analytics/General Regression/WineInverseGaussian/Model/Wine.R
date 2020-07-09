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
# install.packages("rattle")
# install.packages("e1071")

# Load below packages
library(pmml)
library(gmodels)
library(rattle.data) # This package is specifically loaded for wine dataset shipped within it.
library(e1071)

# Here we directly load the wine dataset installed with the "rattle" package.
data(wine)

# rename column names in wine dataset from rattle.data package
wineOriginal <- setNames(wine, c("Type", "Alcohol", "Malic_Acid","Ash","Alcalinity","Magnesium","Phenols","Flavanoids","Non_Flavanoids","Proanthocyanins",
"Color_Intensity","Hue","Dilution","Proline"))

# Omit rows with missing values
wineOriginal = na.omit(wineOriginal)

# Considering integer variable as factor
wineOriginal[, "Type"]=as.integer(wineOriginal[, "Type"])

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.y
# setwd("C:/actual_data_location")
# wine= read.csv("Wine.csv")

# Randomizing data
wine<- wineOriginal[sample(nrow(wineOriginal)),]

# Divide dataset for training and test
trainData<-wine[1:144,]
testData<-wine[145:178,]

# Applying General Regression Model - inverse function to predict Type
wineFormula = formula(Type~ Alcohol+Malic_Acid+Ash+Alcalinity+Magnesium+Phenols+Flavanoids
+ Non_Flavanoids+Proanthocyanins +Color_Intensity+Hue+Dilution+Proline )
wine_GLM = glm(wineFormula , trainData, family = inverse.gaussian(link="inverse"))

# Display the predicted results and create cross table to check on accuracy
# Predict "Type" column probability for test data set
wineTestProbabilities = predict(wine_GLM,type = "response",testData)
# Display predicted probabilities
wineTestProbabilities

# PMML generation
pmmlFile<-pmml(wine_GLM,data=trainData)
write(toString(pmmlFile),file="Wine.pmml")
saveXML(pmmlFile,file="Wine.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original wine data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying General Regression model to entire dataset and save the results in a CSV file
wineEntireProbabilities = predict(wine_GLM, type = "response",wineOriginal)

# Save predicted value in a data frame 
result = data.frame(wineEntireProbabilities)
names(result) = c("Predicted_Type")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)






