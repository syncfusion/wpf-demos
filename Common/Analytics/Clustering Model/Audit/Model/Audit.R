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
# install.packages("rattle")

# Load below packages
library(rattle)
library(pmml)

# Here we directly load the audit dataset installed with the "pmml" package.
data(audit)

# rename column names for audit dataset from pmml package
auditOriginal <- setNames(audit, c("ID", "Age", "Employment", "Education", "Marital", "Occupation", "Income", "Sex", "Deductions", "Hours", "Accounts", "Adjustment", "Adjusted"))

# Omit rows with missing values
auditOriginal <- na.omit(auditOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# audit<- read.csv("Audit.csv")

# Get numeric fields data of audit
numericAuditData <- auditOriginal[,c("ID","Age","Income","Deductions","Hours","Adjustment","Adjusted")]

# Randomizing data
audit<-numericAuditData[sample(nrow(numericAuditData)),]

# Divide dataset for training and test
trainData<-audit[1:1487,]
testData<-audit[1488:1859,]

# Applying KMeans Clustering Algorithm with centroids "2"
audit_KMeans <- kmeans(trainData, 2)
audit_KMeans

# Predict "Adjusted" column for test data set
auditTestPrediction<-predict(audit_KMeans,testData)
# Display predicted values
auditTestPrediction

# PMML generation
pmmlFile<-pmml(audit_KMeans,data=trainData)
write(toString(pmmlFile),file="Audit.pmml")
saveXML(pmmlFile,file="Audit.pmml")

# The code below is used for evaluation purpose.  
# The model is applied for original Audit data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying KMeans Clustering algorithm to entire dataset and save the results in a CSV file
auditEntirePrediction<-predict(audit_KMeans,numericAuditData)
auditEntirePrediction

# Save predicted value in a data frame
result <- data.frame(auditEntirePrediction)
names(result) <- c("Predicted_Adjusted")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)