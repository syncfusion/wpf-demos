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
# install.packages("kernlab")
# install.packages("pmml") 
# install.packages("gmodels") 
# install.packages("randomForest")

# Load below packages
library(kernlab)
library(pmml)
library(randomForest) # This package is specifically loaded for Imports85 dataset shipped within it.
library(gmodels)

# Here we directly load the imports85 dataset installed with the "randomForest" package.
data(imports85)

# rename column names in imports85 dataset from randomForest package
importsOriginal <- setNames(imports85, c("Symboling","Normalized_Losses","Make","Fuel_Type","Aspiration","Num_Of_Doors","Body_Style","Drive_Wheels","Engine_Location",
"Wheel_Base","Length","Width","Height","Curb_Weight","Engine_Type","Num_Of_Cylinders","Engine_Size","Fuel_System","Bore","Stroke","Compression_Ratio",
"Horse_Power","Peak_Rpm","City_Mpg","Highway_Mpg","Price"))

# Omit rows with missing values
importsOriginal  <- na.omit(importsOriginal) 

# Converts ordered factor to normal factor
importsOriginal $Num_Of_Cylinders<-factor(importsOriginal $Num_Of_Cylinders, ordered = FALSE)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# imports<- read.csv("Imports.csv")

# Randomizing data
imports<-importsOriginal [sample(nrow(importsOriginal)),]

# Divide dataset for training and test
trainData<-imports[1:136,]
testData<-imports[137:155,]

# Applying Support vector Machine Function using Linear kernel- "vanilladot"
imports_SVM<-ksvm(Price~.,data=trainData,kernel="vanilladot")
imports_SVM

# Predict "Price" column for test data set
importsTestPrediction<-predict(imports_SVM,testData)
# Display predicted values
importsTestPrediction

# PMML generation
pmmlFile<-pmml(imports_SVM,data=trainData)
write(toString(pmmlFile),file="Imports.pmml")
saveXML(pmmlFile,file="Imports.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original Imports data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Support vector Machine model to entire dataset and save the results in a CSV file
importsEntirePrediction<-predict(imports_SVM,importsOriginal)
importsEntirePrediction

# Save predicted value in a data frame
result = data.frame(importsEntirePrediction)
names(result) = c("Predicted_price")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)