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
# install.packages("mlbench")

# Load below packages
library(randomForest)
library(pmml) 
library(gmodels)
library(mlbench)# This package is specifically loaded for ozone dataset shipped within it.

# Here we directly load the Ozone dataset installed with the "mlbench" package.
data(Ozone)

# rename column names in Ozone dataset from mlbench package 
ozoneOriginal <- setNames(Ozone, c("Month","Day_Of_Month","Day_Of_Week","Ozone_Reading","Pressure","Wind_Speed","Humidity","Sandburg_Temperature",
"ElMonte_Temperature","Inversion_Height","Pressure_Gradient","Inversion_Temperature","Visibility"))

# Omit rows with missing values
ozoneOriginal<- na.omit(ozoneOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# ozone<- read.csv("Ozone.csv")

# Randomizing data
ozone<- ozoneOriginal[sample(nrow(ozoneOriginal)),]

# Divide dataset for training and test
trainData<-ozone[1:162,]
testData<-ozone[163:203,]

# Applying random forest function
ozone_RF<-randomForest(Ozone_Reading~.,data=trainData,ntree=50)
ozone_RF

# Predict "average_ozone_reading" column for test data set
ozoneTestPrediction<-predict(ozone_RF,testData)
# Display predicted values
ozoneTestPrediction

# PMML generation
pmmlFile<-pmml(ozone_RF,data=trainData)
write(toString(pmmlFile),file="Ozone.pmml")
saveXML(pmmlFile,file="Ozone.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original ozone data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Random Forest model to entire dataset and save the results in a CSV file
ozoneEntirePrediction<-predict(ozone_RF,ozoneOriginal)

# Save predicted value in a data frame
result = data.frame(ozoneEntirePrediction)
names(result) = c("Predicted_AverageOzoneReading")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)
