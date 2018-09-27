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

# Load below packages
library(pmml)
library(survival)

# Here we directly load the aml dataset installed with the "survival" package
aml

# rename column names for aml dataset from survival package
amlOriginal <- setNames(aml, c("Survival_Time", "Censoring_Status", "Maintenance_Status"))

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from package.
# setwd("C:/actual_data_location")
# aml= read.csv("Aml.csv")

# Applying Cox Regression Model to predict Survival
aml_Cox = coxph(Surv(Survival_Time,Censoring_Status)~Maintenance_Status, amlOriginal)
summary(aml_Cox)

# Calculate Survival fit of the model
survfit(aml_Cox, amlOriginal)
plot(survfit(aml_Cox))  

# Display the predicted results
# Predict "Survival" column for test data set
amlTestPrediction = predict(aml_Cox, type = "expected",amlOriginal)
# Display predicted values
amlTestPrediction 

# PMML generation
pmmlFile<-pmml(aml_Cox, data=trainData)
write(toString(pmmlFile), file="Aml.pmml")
saveXML(pmmlFile, file="Aml.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original aml data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Cox Regression model to entire dataset and save the results in a CSV file
amlEntirePrediction = predict(aml_Cox, type = "expected", amlOriginal)

# Save predicted value in a data frame
result = data.frame(amlEntirePrediction)
names(result) = c("Predicted_Survival")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)

