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
#install.packages("gbm")
#install.packages("devtools")
#install.packages("rJava")
#install_github(repo = "jpmml/r2pmml")
#install.packages("reshape2")

# Load below packages
library(devtools)
library(gbm)
library(rJava)
library(r2pmml)
library(reshape2) # This package is specifically loaded for tips dataset shipped within it.

# Here we directly load the tips dataset installed with the "reshape2" package.
data(tips)

# rename column names in tips dataset
tipsOriginal <- setNames(tips, c("Total_Bill", "Tip_Amount", "Sex", "Smoker", "Day", "Time", "Size"))

# Omit rows with missing values
tipsOriginal = na.omit(tipsOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# tips= read.csv("Tips.csv")

# Divide dataset for training and test
trainData<-tipsOriginal[1:195,]
testData<-tipsOriginal[196:244,]

# Applying GBM - gaussian function to predict tip
tips_GBM = gbm(Tip_Amount~., data=trainData,distribution="gaussian")

# Display the predicted results and create cross table to check on accuracy
# Predict "tip" column probability for test data set
tipsTestProbabilities = predict.gbm(tips_GBM,type = "response", n.trees=100, newdata=testData)
# Display predicted probabilities
tipsTestProbabilities

# PMML generation
r2pmml(tips_GBM ,"Tips.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original tips data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying GBM to entire dataset and save the results in a CSV file
tipsEntireProbabilities = predict.gbm(tips_GBM, type = "response",n.trees=100,tipsOriginal)

# Save predicted value in a data frame
result = data.frame(tipsEntireProbabilities)
names(result) = c("Predicted_TipAmount")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)



