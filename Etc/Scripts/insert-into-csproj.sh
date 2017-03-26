#!/usr/bin/bash

if [ $# -ne 2 ]; then
    echo "Usage: $0 <csproj-path> <entityNameFirstLower>"
    echo "Example: $0 ../../Src/Common/Domain/Domain.csproj volunteerProfile"
    exit 1
fi

cd "$(dirname "$0")"

CSPROJ_PATH=$1
FILE_NAME=$2

#echo ${CSPROJ_PATH}
echo ${FILE_NAME}

# guard clause - already inserted
echo "cat ${CSPROJ_PATH} |grep -n "${FILE_NAME}""
REQUIRED_LINE=`cat ${CSPROJ_PATH} |grep -n "${FILE_NAME}"`
if [ "${REQUIRED_LINE}" != "" ]; then
    echo "Project already includes file...do nothing additional"
    exit 0
fi

INSERT_LINE_NUMBER=`cat ${CSPROJ_PATH} \
    | grep -n "Compile Include=\"\\\\\\User.cs\"" \
    | awk '{print $1}' \
    | sed 's/:.*$//'`
echo "--"
echo "Insert line ${INSERT_LINE_NUMBER} in: ${CSPROJ_PATH}"
echo "--"
#sed -i "${INSERT_LINE_NUMBER}i \ \ \ \ <Compile Include=\"command\\\\v${VERSION_NO_DOTS}\\\\MainCommand.cs\" />" ${CSPROJ_PATH}
unix2dos ${CSPROJ_PATH}

