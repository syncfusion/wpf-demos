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
# install.packages("survival")
# install.packages("KMsurv")

# Load below packages
library(pmml)
library(survival)
library(KMsurv) #This package is specifically loaded for larynx data shipped within it. 

# Here we directly load the larynx dataset installed with the "KMsurv" package.
data(larynx)

#rename column names for larynx dataset from KMsurv package
larynxOriginal <- setNames(larynx, c("Cancer_Stage", "Survival_Time", "Diagnosed_Age", "Diagnosed_Year", "Death_Indicator"))

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from package.
# setwd("C:/actual_data_location")
# larynx = read.csv("Larynx.csv")

# Divide dataset for training and test
trainData=larynxOriginal[1:72,]
testData=larynxOriginal[73:90,]

# Applying Cox Regression Model to predict Survival
larynx_Cox = coxph(Surv(Survival_Time,Death_Indicator)~Cancer_Stage+Diagnosed_Age+Diagnosed_Year, trainData)
summary(larynx_Cox)

# Calculate Survival fit of the model
survfit(larynx_Cox, trainData)
plot(survfit(larynx_Cox))  

# Display the predicted results
# Predict "Survival" column for test data set
larynxTestPrediction = predict(larynx_Cox, type = "expected",testData)
# Display predicted values
larynxTestPrediction 

# The code below is used for evaluation purpose. 
# The model is applied for original larynx data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Cox Regression model to entire dataset and save the results in a CSV file
larynxEntirePrediction = predict(larynx_Cox, type = "expected", larynxOriginal)

# PMML generation
pmmlFile<-pmml(larynx_Cox, data=trainData)
write(toString(pmmlFile), file="Larynx.pmml")
saveXML(pmmlFile, file="Larynx.pmml")

# Save predicted value in a data frame
result = data.frame(larynxEntirePrediction)
names(result) = c("Predicted_Survival")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)

