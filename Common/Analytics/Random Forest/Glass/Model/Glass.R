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
# install.packages("randomForest")
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("MASS")

# Load below packages
library(randomForest)
library(pmml) 
library(gmodels)
library(MASS)# This package is specifically loaded for fgl dataset shipped within it.

# Here we directly load the fgl dataset installed with the "MASS" package.
data(fgl)

# rename column names in fgl dataset from MASS package
glassOriginal <- setNames(fgl, c("Refractive_Index", "Sodium", "Magnesium", "Aluminium", "Silicon", "Potassium", "Calcium", "Barium", "Iron", "Type"))

# Omit rows with missing values
glassOriginal <- na.omit(glassOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# Glass<- read.csv("Glass.csv")

# Considering the integer variable as factor
glassOriginal[, "Type"]=as.factor(glassOriginal[, "Type"])

# Randomizing data
glass<-glassOriginal[sample(nrow(glassOriginal)),]

# Divide dataset for training and test
trainData<-glass[1:171,]
testData<-glass[172:214,]

# Applying random forest function
glass_RF<-randomForest(Type~.,data=trainData,ntree=50)
glass_RF

# Display the predicted results and  create cross table for accuracy
# Predict "type" column for test data set
glassTestPrediction<-predict(glass_RF,testData)
# Display predicted values
glassTestPrediction

# Create cross table to check on accuracy
CrossTable(glassTestPrediction,testData$Type,
           prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,
           dnn = c('actual', 'predicted'))

# PMML generation
pmmlFile<-pmml(glass_RF,data=trainData)
write(toString(pmmlFile),file="Glass.pmml")
saveXML(pmmlFile,file="Glass.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original fgl data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Random Forest model to entire dataset and save the results in a CSV file
glassEntirePrediction<-predict(glass_RF,glassOriginal)

# predict probability value for entire dataset
Predicted_probabilities<-predict(glass_RF,glassOriginal,type="prob")

# Save predicted value and probabilities in a data frame
result = data.frame(glassEntirePrediction,Predicted_probabilities)
names(result) = c("Predicted_Type","WindowFloatGlassTypeProbability","WindowNon-floatGlassTypeProbability","VehicleWindowGlassTypeProbability","ContainersTypeProbability","TablewareTypeProbability","VehicleHeadlampsTypeProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)
 